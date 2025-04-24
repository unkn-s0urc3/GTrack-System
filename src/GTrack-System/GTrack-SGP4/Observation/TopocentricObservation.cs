using System;
using GTrack_SGP4.CoordinateSystem;
using GTrack_SGP4.Propogation;
using GTrack_SGP4.Util;

namespace GTrack_SGP4.Observation
{
    /// <summary>
    ///     Stores a topocentric location (azimuth, elevation, range and range rate).
    /// </summary>
    public class TopocentricObservation
    {
        /// <summary>
        ///     Azimuth relative to the observer
        /// </summary>
        public Angle Azimuth { get; }

        /// <summary>
        ///     Elevation relative to the observer
        /// </summary>
        public Angle Elevation { get; }

        /// <summary>
        ///     Range relative to the observer, in kilometers
        /// </summary>
        public double Range { get; }

        /// <summary>
        ///     Range rate relative to the observer, in kilometers/second
        /// </summary>
        public double RangeRate { get; }

        /// <summary>
        ///     The position from which the satellite was observed to generate this observation
        /// </summary>
        public Coordinate ReferencePosition { get; }

        /// <summary>
        ///     Direction relative to the observer
        /// </summary>
        public RelativeDirection Direction => GetRelativeDirection();

        /// <summary>
        ///     Time for an ideal radio signal to travel the distance between the observer and the satellite, in seconds
        /// </summary>
        public double SignalDelay => GetSignalDelay();

        /// <summary>
        ///     Creates a new topocentric coordinate at the origin
        /// </summary>
        public TopocentricObservation()
        {
        }

        /// <summary>
        ///     Creates a new topocentric coordinate with the specified values
        /// </summary>
        /// <param name="azimuth">Azimuth</param>
        /// <param name="elevation">Elevation</param>
        /// <param name="range">Range in kilometers</param>
        /// <param name="rangeRate">Range rate in kilometers/second</param>
        /// <param name="referencePosition">The position from which the satellite was observed to generate this observation</param>
        public TopocentricObservation(Angle azimuth, Angle elevation, double range, double rangeRate,
            Coordinate referencePosition = null)
        {
            Azimuth = azimuth;
            Elevation = elevation;
            Range = range;
            RangeRate = rangeRate;
            ReferencePosition = referencePosition;
        }

        /// <summary>
        ///     Creates a new topocentric coordinate as a copy of the specified one
        /// </summary>
        /// <param name="topo">Object to copy from</param>
        public TopocentricObservation(TopocentricObservation topo)
        {
            Azimuth = topo.Azimuth;
            Elevation = topo.Elevation;
            Range = topo.Range;
            RangeRate = topo.RangeRate;
            ReferencePosition = topo.ReferencePosition;
        }

        private double GetSignalDelay()
        {
            return SgpConstants.SpeedOfLight / (Range * SgpConstants.MetersPerKilometer);
        }

        private RelativeDirection GetRelativeDirection()
        {
            if (Math.Abs(RangeRate) < double.Epsilon) return RelativeDirection.Fixed;
            return RangeRate < 0 ? RelativeDirection.Approaching : RelativeDirection.Receding;
        }

        /// <summary>
        ///     Predicts the doppler shift of the satellite relative to the observer, in Hz
        /// </summary>
        /// <param name="inputFrequency">The base RX/TX frequency, in Hz</param>
        /// <returns>The doppler shift of the satellite</returns>
        public double GetDopplerShift(double inputFrequency)
        {
            var rr = RangeRate * SgpConstants.MetersPerKilometer;
            return -rr / SgpConstants.SpeedOfLight * inputFrequency;
        }

        /// <inheritdoc />
        protected bool Equals(TopocentricObservation other)
        {
            return Azimuth.Equals(other.Azimuth) && Elevation.Equals(other.Elevation) && Range.Equals(other.Range) &&
                   RangeRate.Equals(other.RangeRate) && ReferencePosition.Equals(other.ReferencePosition);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is TopocentricObservation top && Equals(top);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Azimuth.GetHashCode();
                hashCode = (hashCode * 397) ^ Elevation.GetHashCode();
                hashCode = (hashCode * 397) ^ Range.GetHashCode();
                hashCode = (hashCode * 397) ^ RangeRate.GetHashCode();
                hashCode = (hashCode * 397) ^ ReferencePosition.GetHashCode();
                return hashCode;
            }
        }

        /// <inheritdoc />
        public static bool operator ==(TopocentricObservation left, TopocentricObservation right)
        {
            return Equals(left, right);
        }

        /// <inheritdoc />
        public static bool operator !=(TopocentricObservation left, TopocentricObservation right)
        {
            return !Equals(left, right);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return
                $"TopocentricObservation[Azimuth={Azimuth}, Elevation={Elevation}, Range={Range}km, RangeRate={RangeRate}km/s]";
        }
    }
}