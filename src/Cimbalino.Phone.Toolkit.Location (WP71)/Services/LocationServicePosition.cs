﻿// ****************************************************************************
// <copyright file="LocationServicePosition.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>20-04-2013</date>
// <project>Cimbalino.Phone.Toolkit.Location</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Globalization;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents a location expressed as a geographic coordinate.
    /// </summary>
    public class LocationServicePosition : IEquatable<LocationServicePosition>
    {
        /// <summary>
        /// Represents a <see cref="LocationServicePosition"/> object with unknown latitude and longitude fields.
        /// </summary>
        public static readonly LocationServicePosition Unknown = new LocationServicePosition();

        #region Properties

        /// <summary>
        /// Gets the time at which the location was determined.
        /// </summary>
        /// <value>The time at which the location was determined.</value>
        public DateTimeOffset Timestamp { get; private set; }

        /// <summary>
        /// Gets the latitude in degrees.
        /// </summary>
        /// <value>The latitude in degrees.</value>
        public double Latitude { get; private set; }

        /// <summary>
        /// Gets the longitude in degrees.
        /// </summary>
        /// <value>The longitude in degrees.</value>
        public double Longitude { get; private set; }

        /// <summary>
        /// Gets the accuracy of the location in meters.
        /// </summary>
        /// <value>The accuracy of the location in meters.</value>
        public double Accuracy { get; private set; }

        /// <summary>
        /// Gets the altitude of the location, in meters.
        /// </summary>
        /// <value>The altitude of the location, in meters.</value>
        public double? Altitude { get; private set; }

        /// <summary>
        /// Gets the accuracy of the altitude, in meters.
        /// </summary>
        /// <value>The accuracy of the altitude, in meters.</value>
        public double? AltitudeAccuracy { get; private set; }

        /// <summary>
        /// Gets the current heading in degrees relative to true north.
        /// </summary>
        /// <value>The current heading in degrees relative to true north.</value>
        public double? Heading { get; private set; }

        /// <summary>
        /// Gets the speed in meters per second.
        /// </summary>
        /// <value>The speed in meters per second.</value>
        public double? Speed { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="LocationServicePosition" /> does not contain latitude or longitude data.
        /// </summary>
        /// <value>true if the <see cref="LocationServicePosition" /> does not contain latitude or longitude data; otherwise, false.</value>
        public bool IsUnknown
        {
            get
            {
                return this == Unknown;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationServicePosition"/> class.
        /// </summary>
        public LocationServicePosition()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationServicePosition"/> class.
        /// </summary>
        /// <param name="timestamp">The time at which the location was determined.</param>
        /// <param name="latitude">The latitude in degrees.</param>
        /// <param name="longitude">The longitude in degrees.</param>
        /// <param name="accuracy">The accuracy of the location in meters.</param>
        /// <param name="altitude">The altitude of the location, in meters.</param>
        /// <param name="altitudeAccuracy">The accuracy of the altitude, in meters.</param>
        /// <param name="heading">The current heading in degrees relative to true north.</param>
        /// <param name="speed">The speed in meters per second.</param>
        public LocationServicePosition(DateTimeOffset timestamp, double latitude, double longitude, double accuracy, double? altitude, double? altitudeAccuracy, double? heading, double? speed)
        {
            Timestamp = timestamp;
            Latitude = latitude;
            Longitude = longitude;
            Accuracy = accuracy;
            Altitude = altitude;
            AltitudeAccuracy = altitudeAccuracy;
            Heading = heading;
            Speed = speed;
        }

        /// <summary>
        /// Determines whether the specified object is a <see cref="LocationServicePosition"/> that has the same latitude and longitude values as this one.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>true if the latitude and longitude properties of both objects have the same value.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((LocationServicePosition)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current <see cref="LocationServicePosition"/>.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Latitude.GetHashCode() * 397) ^ Longitude.GetHashCode();
            }
        }

        /// <summary>
        /// Determines whether two <see cref="LocationServicePosition"/> objects are not equal.
        /// </summary>
        /// <param name="left">The first <see cref="LocationServicePosition"/> to test for inequality.</param>
        /// <param name="right">The second <see cref="LocationServicePosition"/> to test for inequality.</param>
        /// <returns>true if the latitude and longitude values of both <see cref="LocationServicePosition"/> objects are not equal; otherwise, false.</returns>
        public static bool operator !=(LocationServicePosition left, LocationServicePosition right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether two <see cref="LocationServicePosition"/> objects are equal.
        /// </summary>
        /// <param name="left">The first <see cref="LocationServicePosition"/> to test for equality.</param>
        /// <param name="right">The second <see cref="LocationServicePosition"/> to test for equality.</param>
        /// <returns>true if the latitude and longitude values of both <see cref="LocationServicePosition"/> objects are equal; otherwise, false.</returns>
        public static bool operator ==(LocationServicePosition left, LocationServicePosition right)
        {
            return left.Latitude == right.Latitude && left.Longitude == right.Longitude;
        }

        /// <summary>
        /// Determines whether the specified <see cref="LocationServicePosition"/> has the same latitude and longitude values as this one.
        /// </summary>
        /// <param name="other">The <see cref="LocationServicePosition"/> object to compare with the current instance.</param>
        /// <returns>true if the latitude and longitude properties of both objects have the same value; otherwise, false.</returns>
        public bool Equals(LocationServicePosition other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
        }

        /// <summary>
        /// Returns a string representation of the current <see cref="LocationServicePosition"/>.
        /// </summary>
        /// <returns>A string representation of the current <see cref="LocationServicePosition"/>.</returns>
        public override string ToString()
        {
            if (this == Unknown)
            {
                return "Unknown";
            }

            return string.Format(CultureInfo.InvariantCulture, "{0:G}, {1:G}",
                Latitude,
                Longitude);
        }
    }
}