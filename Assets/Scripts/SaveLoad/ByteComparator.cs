using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ByteComparator
{
    public static bool Equals(this byte[] hash, byte[] otherHash)
    {
        int length = hash.Length;
        if (length != otherHash.Length)
            return false;

        for(int i = 0; i < length; i++)
        {
            if (hash[i] != otherHash[i])
                return false;
        }
        return true;
    }
}
