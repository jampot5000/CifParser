﻿using FileHelpers;
using System;

namespace CifParser.Records
{
    /// <summary>
    /// Basic Schedule Extra Data Record: BX
    /// </summary>
    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class ScheduleExtraData : IRecord
    {
        /// <summary>
        ///Record type 
        /// </summary>
        /// <remarks>Length 2, Position 1-2</remarks>
        [FieldFixedLength(2)]
        public string Type { get; set; } = null!;
        /// <summary>
        /// Traction class - NOT USED
        /// </summary>
        /// <remarks>Length 4, Position 3-6</remarks>
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Right)]
        public string TractionClass { get; set; } = string.Empty;
        /// <summary>
        /// UIC Code
        /// </summary>
        /// <remarks>Length 5, Position 7-11
        /// Only populated for services using the channel tunnel</remarks>
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Right)]
        public string UIC { get; set; } = string.Empty;
        /// <summary>
        /// Service Provider - 2 letter ATOC Code
        /// </summary>
        /// <remarks>Length 2, Position 12-13
        /// Values: https://wiki.openraildata.com/index.php?title=TOC_Codes </remarks>
        [FieldFixedLength(2)]
        [FieldTrim(TrimMode.Right)]
        public string Toc { get; set; } = string.Empty;
        /// <summary>
        /// Applicable Timetable Code - performance monitoring
        /// </summary>
        /// <remarks>Length 1, Position 14-14
        /// Values: Y and N </remarks>
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Right)]
        public string ApplicableTimetableCode { get; set; } = string.Empty;
        /// <summary>
        /// Retail Service Id - used by NRS
        /// </summary>
        /// <remarks>Length 8, Position 15-22 
        /// Only returned in RDG version of the CIF
        /// National Rail version is blank</remarks>
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Right)]
        [FieldOptional]
        public string RetailServiceId { get; set; } = string.Empty;
        /// <summary>
        /// Source - NOT USED
        /// </summary>
        /// <remarks>Length 1, Position 23-23 </remarks>
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Right)]
        [FieldOptional]
        public string Source { get; set; } = string.Empty;
        /// <summary>
        /// Spare - NOT USED
        /// </summary>
        /// <remarks>Length 57, Position 24-80</remarks> 
        [FieldFixedLength(57)]
        [FieldTrim(TrimMode.Right)]
        [FieldOptional]
        public string Spare { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Toc} {RetailServiceId}";
        }
    }
}
