﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TelemetryConsole.Src.Misc
{
    /// <summary>
    ///     Performs 32-bit reversed cyclic redundancy checks.
    /// </summary>
    public class Crc32
    {
        #region Constants

        /// <summary>
        ///     Generator polynomial (modulo 2) for the reversed CRC32 algorithm.
        /// </summary>
        private const uint SGenerator = 0xEDB88320;

        #endregion

        #region Fields

        /// <summary>
        ///     Contains a cache of calculated checksum chunks.
        /// </summary>
        private readonly uint[] _mChecksumTable;

        #endregion

        #region Constructors

        /// <summary>
        ///     Creates a new instance of the Crc32 class.
        /// </summary>
        public Crc32()
        {
            // Constructs the checksum lookup table. Used to optimize the checksum.
            _mChecksumTable = Enumerable.Range(0, 256).Select(i =>
            {
                uint tableEntry = (uint) i;
                for (int j = 0; j < 8; ++j)
                    tableEntry = (tableEntry & 1) != 0
                        ? SGenerator ^ (tableEntry >> 1)
                        : tableEntry >> 1;
                return tableEntry;
            }).ToArray();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Calculates the checksum of the byte stream.
        /// </summary>
        /// <param name="byteStream">The byte stream to calculate the checksum for.</param>
        /// <returns>A 32-bit reversed checksum.</returns>
        public uint Get<T>(IEnumerable<T> byteStream)
        {
            try
            {
                if (byteStream != null)
                    // Initialize checksumRegister to 0xFFFFFFFF and calculate the checksum.
                    return ~byteStream.Aggregate(0xFFFFFFFF, (checksumRegister, currentByte) =>
                        _mChecksumTable[(checksumRegister & 0xFF) ^ Convert.ToByte(currentByte)] ^
                        (checksumRegister >> 8));

                return 0;
            }
            catch (FormatException e)
            {
                throw new Exception("Could not read the stream out as bytes.", e);
            }
            catch (InvalidCastException e)
            {
                throw new Exception("Could not read the stream out as bytes.", e);
            }
            catch (OverflowException e)
            {
                throw new Exception("Could not read the stream out as bytes.", e);
            }
        }

        #endregion
    }
}