//  Copyright (c) 2018 Demerzel Solutions Limited
//  This file is part of the Nethermind library.
// 
//  The Nethermind library is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  The Nethermind library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.

using System;
using Nethermind.Core;
using Nethermind.Core.Extensions;
using Nethermind.Core.Specs;
using Nethermind.Crypto.Bls;

namespace Nethermind.Evm.Precompiles.Bls.Mcl
{
    /// <summary>
    /// https://eips.ethereum.org/EIPS/eip-2537
    /// </summary>
    public class G2AddPrecompile : IPrecompile
    {
        public static IPrecompile Instance = new G2AddPrecompile();

        private G2AddPrecompile()
        {
        }

        public Address Address { get; } = Address.FromNumber(13);

        public long BaseGasCost(IReleaseSpec releaseSpec)
        {
            return 4500L;
        }

        public long DataGasCost(byte[] inputData, IReleaseSpec releaseSpec)
        {
            return 0L;
        }

        public (byte[], bool) Run(byte[] inputData)
        {  
            Span<byte> inputDataSpan = stackalloc byte[8 * BlsExtensions.LenFp];
            inputData.PrepareEthInput(inputDataSpan);

            (byte[], bool) result;
            if (inputDataSpan.TryReadEthG2(0 * BlsExtensions.LenFp, out G2 a) &&
                inputDataSpan.TryReadEthG2(4 * BlsExtensions.LenFp, out G2 b))
            {
                a.Add(a, b);
                result = (BlsExtensions.SerializeEthG2(a), true);
            }
            else
            {
                result = (Bytes.Empty, false);
            }
            
            return result;
        }
    }
}