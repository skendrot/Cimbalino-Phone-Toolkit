// ****************************************************************************
// <copyright file="IPhotoChooserService.cs" company="Pedro Lamas">
// Copyright � Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>25-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching the Photo Chooser application. Use this to allow users to select a photo.
    /// </summary>
    public interface IPhotoChooserService
    {
        /// <summary>
        /// Shows the Photo Chooser application.
        /// </summary>
        /// <param name="resultAction">The <see cref="Action{PhotoResult}" /> to be called once the operation is finished.</param>
        void Show(Action<PhotoResult> resultAction);
    }
}