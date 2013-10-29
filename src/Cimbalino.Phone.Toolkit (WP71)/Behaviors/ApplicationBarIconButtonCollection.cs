﻿// ****************************************************************************
// <copyright file="ApplicationBarIconButtonCollection.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
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

using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Behaviors
{
    /// <summary>
    /// Represents a collection of <see cref="IApplicationBarIconButton" />
    /// </summary>
    public class ApplicationBarIconButtonCollection : ApplicationBarItemCollectionBase<IApplicationBarIconButton>
    {
        private const int MaxVisibleIconButtons = 4;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBarIconButtonCollection" /> class.
        /// </summary>
        /// <param name="itemsList">The items list.</param>
        public ApplicationBarIconButtonCollection(System.Collections.IList itemsList)
            : base(itemsList, MaxVisibleIconButtons)
        {
        }
    }
}