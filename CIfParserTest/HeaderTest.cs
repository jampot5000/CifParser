using CifParser;
using CifParser.Records;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace CifParserTest
{
    public class HeaderTest
    {
        private string _records =
@"HDTPS.UDFROC1.PD1901292901191927DFROC1MDFROC1LUA290119290120                    
";

        [Fact]
        public void ReadHeaderRecord()
        {
            var record = ParseRecord();
            Assert.NotNull(record);
        }

        private Header ParseRecord()
        {
            var input = new StringReader(_records);

            var parser = new Parser();

            var records = parser.Read(input);
            return records.First() as Header;
        }

        [Fact]
        public void TypePropertySet()
        {
            var record = ParseRecord();
            Assert.Equal("HD", record.Type);
        }

        [Fact]
        public void MainframePropertySet()
        {
            var record = ParseRecord();
            Assert.Equal("TPS.UDFROC1.PD190129", record.MainframeId);
        }

        [Fact]
        public void ExtractedAtPropertySet()
        {
            var record = ParseRecord();
            Assert.Equal(new DateTime(2019, 1, 29, 19, 27, 0), record.ExtractedAt);
        }

        [Fact]
        public void CurrentFileReferencePropertySet()
        {
            var record = ParseRecord();
            Assert.Equal("DFROC1M", record.CurrentFileReference);
        }

        [Fact]
        public void LastFileReferencePropertySet()
        {
            var record = ParseRecord();
            Assert.Equal("DFROC1L", record.LastFileReference);
        }

        [Fact]
        public void ExtractTypePropertySet()
        {
            var record = ParseRecord();
            Assert.Equal(ExtractType.U, record.ExtractType);
        }

        [Fact]
        public void StartDatePropertySet()
        {
            var record = ParseRecord();
            Assert.Equal(new DateTime(2019, 1, 29, 0, 0, 0), record.StartDate);
        }

        [Fact]
        public void EndDatePropertySet()
        {
            var record = ParseRecord();
            Assert.Equal(new DateTime(2020, 1, 29, 0, 0, 0), record.EndDate);
        }
    }
}