// ****************************************************************************
// <copyright file="ApplicationBarItemBase.cs" company="Pedro Lamas">
// Copyright � Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Behaviors
{
    /// <summary>
    /// Represents a base control for the <see cref="ApplicationBarBehavior" />
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    public abstract class ApplicationBarItemBase<T> : DependencyObject
        where T : IApplicationBarMenuItem
    {
        /// <summary>
        /// Gets the internal item.
        /// </summary>
        /// <value>The internal item.</value>
        internal T Item { get; private set; }

        /// <summary>
        /// Gets or sets the parent <see cref="ApplicationBarItemCollectionBase{T}"/>.
        /// </summary>
        /// <value>The parent <see cref="ApplicationBarItemCollectionBase{T}"/>.</value>
        internal ApplicationBarItemCollectionBase<T> Parent { get; set; }

        private object _commandParameterValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBarItemBase{T}" /> class.
        /// </summary>
        /// <param name="item">The internal item.</param>
        public ApplicationBarItemBase(T item)
        {
            Item = item;
            Item.Text = Text;
            Item.Click += Item_Click;
        }

        /// <summary>
        /// Occurs when a <see cref="ApplicationBarItemBase{T}"/> is clicked.
        /// </summary>
        public event EventHandler Click;

        /// <summary>
        /// Gets or sets a value indicating whether the user can interact with the control.
        /// </summary>
        /// <value>true if the user can interact with the control; otherwise, false.</value>
        public bool IsEnabled
        {
            get
            {
                return (bool)GetValue(IsEnabledProperty);
            }
            set
            {
                SetValue(IsEnabledProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="IsEnabled" /> dependency property
        /// </summary>
        public static readonly DependencyProperty IsEnabledProperty =
        DependencyProperty.Register("IsEnabled", typeof(bool), typeof(ApplicationBarItemBase<T>), new PropertyMetadata(true, OnIsEnabledChanged));

        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                var element = (ApplicationBarItemBase<T>)d;

                element.EnableDisableItem();
            }
        }

        /// <summary>
        /// Gets or sets the text string that is displayed as a label for the item.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                var text = (string)GetValue(TextProperty);

                if (string.IsNullOrEmpty(text))
                {
                    text = "button";
                }

                return text;
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="Text" /> dependency property
        /// </summary>
        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(ApplicationBarItemBase<T>), new PropertyMetadata("button", OnTextChanged));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                var element = (ApplicationBarItemBase<T>)d;

                var text = e.NewValue as string;

                element.Item.Text = text;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item is visible.
        /// </summary>
        /// <value>true if the item is visible; otherwise, false.</value>
        public bool IsVisible
        {
            get
            {
                return (bool)GetValue(IsVisibleProperty);
            }
            set
            {
                SetValue(IsVisibleProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="IsVisible" /> dependency property
        /// </summary>
        public static readonly DependencyProperty IsVisibleProperty =
        DependencyProperty.Register("IsVisible", typeof(bool), typeof(ApplicationBarItemBase<T>), new PropertyMetadata(true, OnIsVisibleChanged));

        private static void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                var element = (ApplicationBarItemBase<T>)d;

                element.UpdateApplicationBar();
            }
        }

        /// <summary>
        /// Gets or sets the command to invoke when this item is pressed. This is a DependencyProperty.
        /// </summary>
        /// <value>The command to invoke when this item is pressed. The default is null.</value>
        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="Command" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
        DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(ApplicationBarItemBase<T>), new PropertyMetadata(null, OnCommandChanged));

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                var element = (ApplicationBarItemBase<T>)d;

                if (e.OldValue != null)
                {
                    ((ICommand)e.OldValue).CanExecuteChanged -= element.Command_CanExecuteChanged;
                }

                if (e.NewValue != null)
                {
                    ((ICommand)e.NewValue).CanExecuteChanged += element.Command_CanExecuteChanged;
                }

                element.EnableDisableItem();
            }
        }

        /// <summary>
        /// Gets or sets the parameter to pass to the <see cref="Command"/> property. This is a DependencyProperty.
        /// </summary>
        /// <value>The parameter to pass to the <see cref="Command"/> property. The default is null.</value>
        public object CommandParameter
        {
            get
            {
                return GetValue(CommandParameterProperty);
            }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }

        /// <summary>
        /// Identifier for the <see cref="CommandParameter" /> dependency property
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(ApplicationBarItemBase<T>), new PropertyMetadata(OnCommandParameterChanged));

        private static void OnCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                var element = (ApplicationBarItemBase<T>)d;

                element.EnableDisableItem();
            }
        }

        /// <summary>
        /// Gets or sets an object that will be passed to the <see cref="Command" /> attached to this trigger. This property is here for compatibility with the Silverlight version. This is NOT a DependencyProperty. For databinding, use the <see cref="CommandParameter" /> property.
        /// </summary>
        /// <value>The parameter value to pass to the <see cref="Command"/> property. The default is null.</value>
        public object CommandParameterValue
        {
            get
            {
                return _commandParameterValue ?? CommandParameter;
            }
            set
            {
                _commandParameterValue = value;

                EnableDisableItem();
            }
        }

        private void EnableDisableItem()
        {
            var isEnabled = IsEnabled;
            var command = Command;

            if (isEnabled && command != null)
            {
                var commandParameter = CommandParameterValue;

                isEnabled = command.CanExecute(commandParameter);
            }

            Item.IsEnabled = isEnabled;
        }

        private void UpdateApplicationBar()
        {
            if (Parent != null)
            {
                Parent.UpdateApplicationBar();
            }
        }

        private void FocusedTextBoxUpdateSource()
        {
            var focusObj = FocusManager.GetFocusedElement();

            if (focusObj != null)
            {
                if (focusObj is TextBox)
                {
                    var binding = ((TextBox)focusObj).GetBindingExpression(TextBox.TextProperty);

                    if (binding != null)
                    {
                        binding.UpdateSource();
                    }
                }
                else if (focusObj is PasswordBox)
                {
                    var binding = ((PasswordBox)focusObj).GetBindingExpression(PasswordBox.PasswordProperty);

                    if (binding != null)
                    {
                        binding.UpdateSource();
                    }
                }
            }
        }

        private void Command_CanExecuteChanged(object sender, EventArgs e)
        {
            EnableDisableItem();
        }

        private void Item_Click(object sender, EventArgs e)
        {
            FocusedTextBoxUpdateSource();

            var eventHandler = Click;

            if (eventHandler != null)
            {
                eventHandler(this, null);
            }

            var command = Command;

            if (command != null)
            {
                var commandParameter = CommandParameterValue;

                if (command.CanExecute(commandParameter))
                {
                    command.Execute(commandParameter);
                }
            }
        }
    }
}