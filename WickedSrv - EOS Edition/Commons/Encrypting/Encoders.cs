using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WickedSrv___EOS_Edition.Commons.Encrypting
{
    class Encoders
    {
        private static int CRYPT_SHIFT = 8;
        private static int CRYPT_MIN_RANGE = 32;
        private static int CRYPT_MAX_RANGE = 126;
        private static int CRYPT_RANGE = 95;
        public static char CharConverter(int n)
        {
            return (char)n;
        }
        public static String DecryptMsg(String Param1, bool Param2)
        {
            var _loc_3 = "";
            var _loc_4 = (Param2 ? (-1) : (1)) * CRYPT_SHIFT;
            var _loc_5 = 0;
            while (_loc_5 < Param1.Length)
            {
                _loc_3 = _loc_3 + CharConverter(DecryptChar(Param1[_loc_5], _loc_4));
                _loc_5++;
            }
            return _loc_3;
        }
        public static int DecryptChar(int param1, int param2)
        {
            if (!inAllowedCharRange(param1, true))
            {

            }
            param2 = param2 % CRYPT_RANGE;
            var _loc_3 = param1 + param2;
            if (_loc_3 < CRYPT_MIN_RANGE)
            {
                _loc_3 = _loc_3 + CRYPT_RANGE;
            }
            else if (_loc_3 > CRYPT_MAX_RANGE)
            {
                _loc_3 = _loc_3 - CRYPT_RANGE;
            }
            return _loc_3;
        }
        public static bool inAllowedCharRange(int param1, bool param2)
        {
            if (param1 < CRYPT_MIN_RANGE || param1 > CRYPT_MAX_RANGE)
            {
                return false;
            }
            return true;
        }
    }
}
