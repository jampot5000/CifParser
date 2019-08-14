using System.IO;
using CifExtractor;
using NSubstitute;
using Serilog;
using Xunit;

namespace CifExtractorTest
{
    public class NrodZipExtractorTest
    {
        private static readonly string cifGzipFile =  Path.Combine(".", "Data", "toc-update-tue.CIF.gz");
               
        [Fact]
        public void CanReadCifFile()
        {
            var archive = new Archive(cifGzipFile, Substitute.For<ILogger>());
            var extractor = new NrodZipExtractor(archive);

            using (var reader = extractor.ExtractCif())
            {
                var first = reader.ReadLine();
                Assert.NotEmpty(first);
            }
        }
    }
    
    public class RdgZipExtractorTest
    {
        private static readonly string rdgZipFile = Path.Combine(".", "Data", "ttis144.zip");
               
        [Fact]
        public void CanReadCifFile()
        {
            var archive = new Archive(rdgZipFile, Substitute.For<ILogger>());
            var extractor = new RdgZipExtractor(archive,  Substitute.For<ILogger>());

            using (var reader = extractor.ExtractCif())
            {
                var first = reader.ReadLine();
                Assert.NotEmpty(first);
            }
        }
       
        [Fact]
        public void CanReadStationFile()
        {
            var archive = new Archive(new FileInfo(rdgZipFile), Substitute.For<ILogger>());
            var extractor = new RdgZipExtractor(archive,  Substitute.For<ILogger>());

            using (var reader = extractor.ExtractFile(RdgZipExtractor.StationExtension))
            {
                var first = reader.ReadLine();
                Assert.NotNull(first);
            }
        }
    }
}