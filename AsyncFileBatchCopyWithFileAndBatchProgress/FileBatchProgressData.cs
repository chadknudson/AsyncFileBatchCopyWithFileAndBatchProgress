namespace AsyncFileBatchCopyWithFileAndBatchProgress
{
    public class FileBatchProgressData
    {
        public long BatchFileCount { get; set; }
        public long BatchFileIndex { get; set; }
        public long BatchLength { get; set; }
        public long BatchPosition { get; set; }
        public string Filename { get; set; }
        public long FileLength { get; set; }
        public long FilePosition { get; set; }
    }
}
