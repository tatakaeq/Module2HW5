using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Module2HW5.Helper
{
    public class LastModifiedFileCheck : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            if (x?.LastWriteTimeUtc > y?.LastWriteTimeUtc)
            {
                return 1;
            }
            else if (y?.LastWriteTimeUtc > x?.LastWriteTimeUtc)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}