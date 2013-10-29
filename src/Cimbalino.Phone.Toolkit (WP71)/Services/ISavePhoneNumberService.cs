﻿// ****************************************************************************
// <copyright file="ISavePhoneNumberService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
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

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of launching the contacts application. Use this to allow users to save a phone number from your application to a new or existing contact.
    /// </summary>
    public interface ISavePhoneNumberService
    {
        /// <summary>
        /// Shows the contacts application, using the specified phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number that can be saved to a contact.</param>
        void Show(string phoneNumber);
    }
}