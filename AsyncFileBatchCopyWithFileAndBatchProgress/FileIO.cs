using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncFileBatchCopyWithFileAndBatchProgress
{
    public static class FileIO
	{
		public static long GetFileBatchLength(string[] files)
		{
			long bytes = 0;

			foreach (string filename in files)
			{
				bytes += new FileInfo(filename).Length;
			}
			return bytes;
		}

		public static async Task CopyFilesAsync(Dictionary<string, string> files, IProgress<FileBatchProgressData> progress, CancellationToken cancellationToken = default(CancellationToken))
		{
			long batchPosition = 0;
			long batchLength = GetFileBatchLength(files.Keys.ToArray());

			foreach (string sourceFile in files.Keys)
			{
				string targetFile = files[sourceFile];

				cancellationToken.ThrowIfCancellationRequested();
				long sourceFileLength = new FileInfo(sourceFile).Length;
				FileBatchProgressData progressData = new FileBatchProgressData() { BatchFileCount = files.Count, BatchFileIndex = 0,  Filename = sourceFile, BatchLength = batchLength, BatchPosition = batchPosition, FileLength = sourceFileLength, FilePosition = 0 };
				progress.Report(progressData);
				await CopyFileInternalAsync(sourceFile, targetFile, progress, batchLength, batchPosition, files.Count, progressData.BatchFileIndex, cancellationToken);
				batchPosition += sourceFileLength;
				progressData.BatchPosition = batchPosition;
				progressData.FilePosition = sourceFileLength;
				progressData.BatchFileIndex++;
				progress.Report(progressData);
			}
		}

		private static async Task CopyFileInternalAsync(string sourceFilename, string targetFilename, IProgress<FileBatchProgressData> progress, long batchLength, long batchPosition, long batchFileCount, long batchFileIndex, CancellationToken cancellationToken = default(CancellationToken))
		{
			int bufferSize = 81920; // Default buffer size used by .NET for file copy. use a smaller number like 8192 if you want to see your file transferred in a lot smaller chunks to better visualize the progress bar at work
			byte[] buffer = new byte[bufferSize];
			int bytesRead;

			long bytesTotal = 0;
			long fileLength = new FileInfo(sourceFilename).Length;

			try
			{
				using (var outStream = new FileStream(targetFilename, FileMode.Create, FileAccess.Write, FileShare.Read))
				{
					using (var inStream = new FileStream(sourceFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						while ((bytesRead = await inStream.ReadAsync(buffer, 0, bufferSize)) > 0)
						{
							await outStream.WriteAsync(buffer, 0, bytesRead);
							cancellationToken.ThrowIfCancellationRequested();
							bytesTotal += bytesRead;
							batchPosition += bytesRead;

							FileBatchProgressData data = new FileBatchProgressData() { BatchFileCount = batchFileCount, BatchFileIndex = batchFileIndex, BatchLength = batchLength, BatchPosition = batchPosition, Filename = sourceFilename, FileLength = fileLength, FilePosition = bytesTotal };
							progress.Report(data);
						}
					}
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
		}
	}
}