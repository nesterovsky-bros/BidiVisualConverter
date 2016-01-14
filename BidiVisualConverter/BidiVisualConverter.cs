namespace NesterovskyBros.Bidi
{
  /// <summary>
  /// An utility to convert visual string to logical.
  /// </summary>
  public static class BidiConverter
  {
    /// <summary>
    /// Converts visual string to logical.
    /// </summary>
    /// <param name="value">A value to convert.</param>
    /// <param name="rtl">A base direction.</param>
    /// <param name="direction">
    /// true for visual to logical, and false for logical to visual.
    /// </param>
    /// <returns>Converted string.</returns>
    public static string Convert(string value, bool rtl, bool direction)
    {
      if (value == null)
      {
        return null;
      }

      int count = value.Length;

      if (count <= 1)
      {
        return value;
      }

      if (NativeMethods.ScriptIsComplex(
        value, 
        count,
        Constants.SIC_COMPLEX | Constants.SIC_NEUTRAL) !=
          Constants.S_OK)
      {
        return value;
      }

      var control = new SCRIPT_CONTROL();
      var state = new SCRIPT_STATE();
      int resultCount = 0;
      int maxCount = count + 1;

      //control.fInvertPreBoundDir = rtl ? 1 : 0;
      //control.fInvertPostBoundDir = rtl ? 1 : 0;
      state.uBidiLevel = rtl ? (ushort)1 : (ushort)0;

      var items = new SCRIPT_ITEM[maxCount];

      if (NativeMethods.ScriptItemize(
        value, 
        count, 
        maxCount, 
        ref control, 
        ref state, 
        items, 
        out resultCount) != 0)
      {
        return value;
      }

      byte[] levels = new byte[count];

      for(int i = 0; i < resultCount; i++)
      {
        var level = items[i].a.s.uBidiLevel;

        for(int j = items[i].iCharPos, k = items[i + 1].iCharPos; j < k; j++)
        {
          levels[j] = (byte)level;
        }
      }

      var orders = new int[count];

      if (NativeMethods.ScriptLayout(count, levels, orders, null) != 0)
      {
        return value;
      }

      var result = new char[count];

      for(int i = 0; i < count; i++)
      {
        var index = orders[i];
        var c = value[index];
        var level = levels[index];

        if (direction && ((level & 1) == 1))
        {
          // Minimal mirroring.
          switch(c)
          {
            case '{':
            {
              c = '}';

              break;
            }
            case '}':
            {
              c = '{';

              break;
            }
            case '(':
            {
              c = ')';

              break;
            }
            case ')':
            {
              c = '(';

              break;
            }
            case '<':
            {
              c = '>';

              break;
            }
            case '>':
            {
              c = '<';

              break;
            }
          }
        }

        result[i] = c;
      }

      return new string(result, 0, count);
    }
  }
}
