# BidiVisualConverter
<b>Bidi visual to logical and vice versa converter.</b>

<div>Oftentimes we deal with Hebrew in .NET.</div>
<div>The task we face again and again is attempt to convert a Hebrew text from visual to logical representation. The latest demand of
such task was when we processed content extracted from PDF. It's turned out that PDF stores content as graphic primitives, and as result text is stored visually (often each letter is kept separately).</div>
<div>We've solved this task with a small wrapper around an <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/dd374091(v=vs.85).aspx">Uniscribe API</a>:</div>
<pre>
namespace NesterovskyBros.Bidi
{
  /// <summary>
  /// An utility to convert visual string to logical.
  /// <summary>
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
    public static string Convert(string value, bool rtl, bool direction);
    ...
  }
}
</pre>
