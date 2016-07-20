# BidiVisualConverter
<b>Bidi visual to logical and vice versa converter.</b>

<div>Oftentimes we deal with Hebrew in .NET.</div>
<div>The task we face again and again is attempt to convert a Hebrew text from visual to logical representation. The latest demand of
such task was when we processed content extracted from PDF. It's turned out that PDF stores content as graphic primitives, and as result text is stored visually (often each letter is kept separately).</div>
<div>We've solved this task with a small wrapper around an <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/dd374091(v=vs.85).aspx">Uniscribe API</a>:</div>
<pre>namespace NesterovskyBros.Bidi
{
  /// &lt;summary>
  /// An utility to convert visual string to logical.
  /// &lt;summary>
  public static class BidiConverter
  {
    /// &lt;summary>
    /// Converts visual string to logical.
    /// &lt;/summary>
    /// &lt;param name="value">A value to convert.&lt;/param>
    /// &lt;param name="rtl">A base direction.&lt;/param>
    /// &lt;param name="direction">
    /// true for visual to logical, and false for logical to visual.
    /// &lt;/param>
    /// &lt;returns>Converted string.&lt;/returns>
    public static string Convert(string value, bool rtl, bool direction);
    ...
  }
}</pre>

<p><a href="Tests/UnitTest.cs">UnitTest.cs</a> shows how to use this API.</p>
