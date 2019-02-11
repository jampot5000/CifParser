﻿using CifParser.Records;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CifParserTest
{
    public class TerminalLocationTest
    {
        private const string _terminal = @"LTMNCRPIC 2038 203810 SL TF                                                     ";


        [Fact]
        public void ReadLocationRecord()
        {
            var record = ParseRecord();
            Assert.NotNull(record);
        }

        private TerminalLocation ParseRecord(string record = null)
        {
            return ParserTest.ParseRecords(record ?? _terminal)[0] as TerminalLocation;
        }

        [Fact]
        public void TypePropertySet()
        {
            var record = ParseRecord();
            Assert.Equal("LT", record.Type);
        }

        [Fact]
        public void LocationPropertySet()
        {
            var record = ParseRecord();
            Assert.Equal("MNCRPIC", record.Location);
        }

        [Fact]
        public void SequencePropertySetToOneWhenNone()
        {
            var record = ParseRecord();
            Assert.Equal(1, record.Sequence);
        }

        [Fact]
        public void WorkingArrivalPropertySet()
        {
            var record = ParseRecord();
            Assert.Equal(new TimeSpan(20, 38, 0), record.WorkingArrival);
        }


        [Fact]
        public void PublicArrivalPropertySet()
        {
            var record = ParseRecord();
            Assert.Equal(new TimeSpan(20, 38, 0), record.PublicArrival);
        }

        [Fact]
        public void PlatformPropertySet()
        {
            var record = ParseRecord();
            Assert.Equal("10", record.Platform);
        }

        [Fact]
        public void ActivitiesPropertySet()
        {
            var record = ParseRecord();
            Assert.Equal("TF", record.Activities);
        }
    }
}
