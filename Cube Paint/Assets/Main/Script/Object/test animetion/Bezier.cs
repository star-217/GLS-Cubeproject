using UnityEngine;
using System.Collections;

public class Bezier
{
  #region プロパティ

  /// <summary>
  /// 始点
  /// </summary>
  public Vector2 P1
  {
    get;
    set;
  }

  /// <summary>
  /// 始点制御点
  /// </summary>
  public Vector2 P2
  {
    get;
    set;
  }

  /// <summary>
  /// 終点制御点
  /// </summary>
  public Vector2 P3
  {
    get;
    set;
  }

  /// <summary>
  /// 終点
  /// </summary>
  public Vector2 P4
  {
    get;
    set;
  }

  /// <summary>
  /// パラメータが有効かどうか取得します。
  /// </summary>
  public bool IsValid
  {
    get
    {
      if( P1 == null ) return false;
      if( P2 == null ) return false;
      if( P3 == null ) return false;
      if( P4 == null ) return false;
      return true;
    }
  }

  #endregion
  
  #region メソッド

  /// <summary>
  /// パラメータt(0～1)を指定して位置を取得します。
  /// </summary>
  /// <param name="t"></param>
  /// <returns></returns>
  public Vector2 GetPosition( float t )
  {
    if( t <= 0 ) return new Vector2(P1.x, P1.y);
    if( t >= 1 ) return new Vector2(P2.x, P2.y);

    var x1 = P1.x;
    var x2 = P2.x;
    var x3 = P3.x;
    var x4 = P4.x;
    var y1 = P1.y;
    var y2 = P2.y;
    var y3 = P3.y;
    var y4 = P4.y;
    var tp = 1 - t;
    var x = t * t * t * x4 + 3 * t * t * tp * x3 + 3 * t * tp * tp * x2 + tp * tp * tp * x1;
    var y = t * t * t * y4 + 3 * t * t * tp * y3 + 3 * t * tp * tp * y2 + tp * tp * tp * y1;
    return new Vector2(x, y);
  }

  #endregion
}
