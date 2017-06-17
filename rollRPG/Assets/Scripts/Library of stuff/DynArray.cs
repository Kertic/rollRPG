using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DynArray<Type>
{
    int mSize;
    int mCapacity;
    Type[] mArray;
    public DynArray()
    {
        mSize = 0;
        mCapacity = 1;
        mArray = new Type[mCapacity];
    }


    /// <summary>
    /// This will add inItem at the end of the array
    /// </summary>
    /// <param name="inItem"> The item to add at the end of the array</param>
    public void AddToArray(Type inItem)
    {
        if (mSize >= mCapacity)//If we don't have room
            DoubleArray();

        mArray[mSize] = inItem;
        ++mSize;

    }

    /// <summary>
    /// This will add inItem to the array in the specified index, and move all items forward that are ahead of it
    /// </summary>
    /// <param name="inItem"> The item to add in</param>
    /// <param name="arrayIndex"> The index the item will end up at</param>
    public void AddToArray(Type inItem, int arrayIndex)
    {
        if (arrayIndex <= mSize && arrayIndex > -1)//If the index is smaller or equal to the total amount of items + 1  (because they can add it at the end of the array and make it the last one)
        {
            if (arrayIndex == mSize)//The case where it would've just made sense to use AddToArray
            {
                AddToArray(inItem);

            }
            else//The case where it will always have to move some forward
            {
                if (mSize == mCapacity)//Only needed if we have no room left
                    DoubleArray();

                for (int i = mSize; i > arrayIndex; i--)//We start at the first actual filled item, which is always mSize - 1, and we go until we've done a pass over each array index
                {

                    Type tempToSwap = mArray[i - 1];
                    mArray[i - 1] = mArray[i];
                    mArray[i] = tempToSwap;
                }


                mArray[arrayIndex] = inItem;
                ++mSize;


            }
        }

    }
    /// <summary>
    /// Removes the item at the index and then moves all items in front of it to fill in
    /// </summary>
    /// <param name="arrayIndex">Index to remove</param>
    public void RemoveFromArray(int arrayIndex)
    {

        for (int i = arrayIndex; i < mSize - 1; i++)
        {
            Type temp = mArray[i];
            mArray[i] = mArray[i + 1];
            mArray[i + 1] = temp;
        }
        --mSize;

    }

    /// <summary>
    /// Removes the first instance of itemToRemove, or all if removeAll is true
    /// </summary>
    /// <param name="itemToRemove">This item will be removed</param>
    /// <param name="removeAll">Put true to remove all items, and false to not remove them</param>
    public void RemoveFromArray(Type itemToRemove, bool removeAll)
    {
        for (int i = 0; i < mSize; i++)
        {
            Type temp = mArray[i];
            if (temp.Equals(itemToRemove))
            {
                
                RemoveFromArray(i);
                if (!removeAll)//This is where we break if we dont want to remove all
                    break;
                i--;
                
            }


        }
    }

    void DoubleArray()
    {
        mCapacity *= 2;
        Type[] tempArray = new Type[mCapacity];
        for (int i = 0; i < mSize; i++)
        {
            tempArray[i] = mArray[i];
        }
        mArray = tempArray;
    }

    public Type[] GetCopyOfArray()
    {
        Type[] temp = new Type[mSize];
        for (int i = 0; i < mSize; i++)
        {
            temp[i] = mArray[i];
        }

        return temp;
    }

    //This overrides the brackets so we can do that instead of GetCopyOfArray for everything.
    public Type this[int key]
    {
        get
        {
            return mArray[key];
        }
        set
        {
            mArray[key] = value; 
        }
    }

    public int GetSize()
    {
        return mSize;
    }

}
