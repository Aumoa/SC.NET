// Copyright 2020 Aumoa.lib. All right reserved.

using System;

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 4개의 부동소수점을 사용하는 색상 값을 표현합니다.
    /// </summary>
    public struct Color : INearlyEquatable<Color, float>, IFormattable, IVectorType
    {
		/// <summary>
		/// 빨간색 색상 값을 나타냅니다.
		/// </summary>
		public float R;

		/// <summary>
		/// 초록색 색상 값을 나타냅니다.
		/// </summary>
		public float G;

		/// <summary>
		/// 파란색 색상 값을 나타냅니다.
		/// </summary>
		public float B;

		/// <summary>
		/// 알파 색상 값을 나타냅니다.
		/// </summary>
		public float A;

		/// <summary>
		/// <see cref="Color"/> 구조체의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="r"> 빨간색 값을 전달합니다. </param>
		/// <param name="g"> 초록색 값을 전달합니다. </param>
		/// <param name="b"> 파란색 값을 전달합니다. </param>
		/// <param name="a"> 알파 값을 전달합니다. </param>
		public Color(float r, float g, float b, float a = 1)
		{
			R = r;
			G = g;
			B = b;
			A = a;
		}

        /// <summary>
        /// <see cref="System.Drawing.Color"/> 구조체로부터 <see cref="Color"/> 구조체의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="color"> 시스템 컬러 값을 전달합니다. </param>
		public Color(System.Drawing.Color color)
		{
			R = color.R / 255;
			G = color.G / 255;
			B = color.B / 255;
			A = color.A / 255;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public override string ToString()
		{
			return string.Format("{{R = {0}, G = {1}, B = {2}, A = {3}}}", R, G, B, A);
		}

		/// <summary>
		/// 지정한 개체가 <see cref="Color"/> 구조체인지 여부 및 지정한 개체의 값이 이 개체의 값과 일치하는지 검사합니다.
		/// </summary>
		/// <param name="right"> 대상 개체를 전달합니다.  </param>
		/// <returns> 값의 일치 여부가 반환됩니다. </returns>
		public override bool Equals(object right)
        {
			if (right is Color c)
            {
				return Equals(c);
            }
			else
            {
				return base.Equals(right);
            }
        }

		/// <summary>
		/// 이 인스턴스의 해시 코드를 반환합니다.
		/// </summary>
		/// <returns> 해시 값이 반환됩니다. </returns>
		public override int GetHashCode()
		{
			return R.GetHashCode() ^ G.GetHashCode() ^ B.GetHashCode() ^ A.GetHashCode();
		}

		/// <summary>
		/// 지정한 개체의 값이 이 개체의 값과 일치하는지 검사합니다.
		/// </summary>
		/// <param name="color"> 대상 개체를 전달합니다.  </param>
		/// <returns> 값의 일치 여부가 반환됩니다. </returns>
		public bool Equals(Color color)
        {
			return this == color;
        }

		/// <inheritdoc/>
		public bool NearlyEquals(in Color right, float epsilon)
		{
			return Math.Abs(R - right.R) <= epsilon
				&& Math.Abs(G - right.G) <= epsilon
				&& Math.Abs(B - right.B) <= epsilon
				&& Math.Abs(A - right.A) <= epsilon;
		}

		/// <summary>
		/// 구조체의 간단한 텍스트 형식을 생성하여 반환합니다.
		/// </summary>
		/// <param name="format"> 서식 텍스트를 전달합니다. </param>
		/// <param name="formatProvider"> 서식 제공 문화권 정보를 전달합니다. </param>
		/// <returns> 생성된 텍스트 개체가 반환됩니다. </returns>
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("{{R = {0}, G = {1}, B = {2}, A = {3}}}",
				R.ToString(format, formatProvider),
				G.ToString(format, formatProvider),
				B.ToString(format, formatProvider),
				A.ToString(format, formatProvider)
			);
		}

		/// <inheritdoc/>
		public float GetComponentOrDefault(int index)
        {
			return index switch
			{
				0 => R,
				1 => G,
				2 => B,
				3 => A,
				_ => default
			};
        }

		/// <inheritdoc/>
		public void Construct<T>(in T vector) where T : IVectorType
		{
			if (vector is not null)
			{
				R = vector.GetComponentOrDefault(0);
				G = vector.GetComponentOrDefault(1);
				B = vector.GetComponentOrDefault(2);
				A = vector.GetComponentOrDefault(3);
			}
			else
			{
				R = 0;
				G = 0;
				B = 0;
				A = 0;
			}
		}

		/// <inheritdoc/>
		public T Convert<T>() where T : IVectorType, new()
		{
			var value = new T();
			value.Construct(in this);
			return value;
		}

		/// <inheritdoc/>
		public bool Contains(int index)
        {
			return index >= 0 && index < 3;
        }

		/// <inheritdoc/>
		public float this[int index]
		{
			get => GetComponentOrDefault(index);
			set
            {
				switch (index)
                {
					case 0:
						R = value;
						break;
					case 1:
						G = value;
						break;
					case 2:
						B = value;
						break;
					case 3:
						A = value;
						break;
                }
            }
		}

		/// <inheritdoc/>
		public int Count
		{
			get => 4;
		}

		/// <summary>
		/// 개체를 <see cref="System.Drawing.Color"/> 구조체 형식으로 변환합니다.
		/// </summary>
		public System.Drawing.Color SystemColor
		{
			get => System.Drawing.Color.FromArgb((int)(R * 255.0f), (int)(G * 255.0f), (int)(B * 255.0f), (int)(A * 255.0f));
		}

        /// <summary>
        /// <see cref="System.Drawing.Color"/> 구조체로부터 <see cref="Color"/> 개체를 생성합니다.
        /// </summary>
        /// <param name="color"> 시스템 색상 값을 전달합니다. </param>
        /// <returns> 생성된 색상 값이 반환됩니다. </returns>
		public static Color FromSystemColor(System.Drawing.Color color)
        {
			return new Color(color);
        }

		/// <summary>
		/// HTML 텍스트 파싱 정보로부터 <see cref="Color"/> 개체를 생성합니다.
		/// </summary>
		/// <param name="html"> HTML 텍스트 컬러 정보를 전달합니다. </param>
		/// <returns> 생성된 색상 값이 반환됩니다. </returns>
		public static Color FromHtml(string html)
		{
			return FromSystemColor(System.Drawing.ColorTranslator.FromHtml(html));
		}

		/// <summary>
		/// 두 색상 값이 같은지 비교합니다.
		/// </summary>
		/// <param name="left"> 첫 번째 색상 값을 전달합니다. </param>
		/// <param name="right"> 두 번째 색상 값을 전달합니다. </param>
		/// <returns> 비교 결과가 반환됩니다. </returns>
		public static bool operator ==(Color left, Color right)
		{
			return left.R == right.R
				&& left.G == right.G
				&& left.B == right.B
				&& left.A == right.A;
		}

		/// <summary>
		/// 두 색상 값이 다른지 비교합니다.
		/// </summary>
		/// <param name="left"> 첫 번째 색상 값을 전달합니다. </param>
		/// <param name="right"> 두 번째 색상 값을 전달합니다. </param>
		/// <returns> 비교 결과가 반환됩니다. </returns>
		public static bool operator !=(Color left, Color right)
		{
			return left.R != right.R
				|| left.G != right.G
				|| left.B != right.B
				|| left.A != right.A;
		}
		
		/// <summary>
		/// 미리 정의된 #F0F8FF 색을 가져옵니다.
		/// </summary>
		public static Color AliceBlue
		{
			get => FromHtml("#F0F8FF");
		}

		/// <summary>
		/// 미리 정의된 #FAEBD7 색을 가져옵니다.
		/// </summary>
		public static Color AntiqueWhite
		{
			get => FromHtml("#FAEBD7");
		}

		/// <summary>
		/// 미리 정의된 #00FFFF 색을 가져옵니다.
		/// </summary>
		public static Color Aqua
		{
			get => FromHtml("#00FFFF");
		}

		/// <summary>
		/// 미리 정의된 #7FFFD4 색을 가져옵니다.
		/// </summary>
		public static Color Aquamarine
		{
			get => FromHtml("#7FFFD4");
		}

		/// <summary>
		/// 미리 정의된 #F0FFFF 색을 가져옵니다.
		/// </summary>
		public static Color Azure
		{
			get => FromHtml("#F0FFFF");
		}

		/// <summary>
		/// 미리 정의된 #F5F5DC 색을 가져옵니다.
		/// </summary>
		public static Color Beige
		{
			get => FromHtml("#F5F5DC");
		}

		/// <summary>
		/// 미리 정의된 #FFE4C4 색을 가져옵니다.
		/// </summary>
		public static Color Bisque
		{
			get => FromHtml("#FFE4C4");
		}

		/// <summary>
		/// 미리 정의된 #000000 색을 가져옵니다.
		/// </summary>
		public static Color Black
		{
			get => FromHtml("#000000");
		}

		/// <summary>
		/// 미리 정의된 #FFEBCD 색을 가져옵니다.
		/// </summary>
		public static Color BlanchedAlmond
		{
			get => FromHtml("#FFEBCD");
		}

		/// <summary>
		/// 미리 정의된 #0000FF 색을 가져옵니다.
		/// </summary>
		public static Color Blue
		{
			get => FromHtml("#0000FF");
		}

		/// <summary>
		/// 미리 정의된 #8A2BE2 색을 가져옵니다.
		/// </summary>
		public static Color BlueViolet
		{
			get => FromHtml("#8A2BE2");
		}

		/// <summary>
		/// 미리 정의된 #A52A2A 색을 가져옵니다.
		/// </summary>
		public static Color Brown
		{
			get => FromHtml("#A52A2A");
		}

		/// <summary>
		/// 미리 정의된 #DEB887 색을 가져옵니다.
		/// </summary>
		public static Color BurlyWood
		{
			get => FromHtml("#DEB887");
		}

		/// <summary>
		/// 미리 정의된 #5F9EA0 색을 가져옵니다.
		/// </summary>
		public static Color CadetBlue
		{
			get => FromHtml("#5F9EA0");
		}

		/// <summary>
		/// 미리 정의된 #7FFF00 색을 가져옵니다.
		/// </summary>
		public static Color Chartreuse
		{
			get => FromHtml("#7FFF00");
		}

		/// <summary>
		/// 미리 정의된 #D2691E 색을 가져옵니다.
		/// </summary>
		public static Color Chocolate
		{
			get => FromHtml("#D2691E");
		}

		/// <summary>
		/// 미리 정의된 #FF7F50 색을 가져옵니다.
		/// </summary>
		public static Color Coral
		{
			get => FromHtml("#FF7F50");
		}

		/// <summary>
		/// 미리 정의된 #6495ED 색을 가져옵니다.
		/// </summary>
		public static Color CornflowerBlue
		{
			get => FromHtml("#6495ED");
		}

		/// <summary>
		/// 미리 정의된 #FFF8DC 색을 가져옵니다.
		/// </summary>
		public static Color Cornsilk
		{
			get => FromHtml("#FFF8DC");
		}

		/// <summary>
		/// 미리 정의된 #DC143C 색을 가져옵니다.
		/// </summary>
		public static Color Crimson
		{
			get => FromHtml("#DC143C");
		}

		/// <summary>
		/// 미리 정의된 #00FFFF 색을 가져옵니다.
		/// </summary>
		public static Color Cyan
		{
			get => FromHtml("#00FFFF");
		}

		/// <summary>
		/// 미리 정의된 #00008B 색을 가져옵니다.
		/// </summary>
		public static Color DarkBlue
		{
			get => FromHtml("#00008B");
		}

		/// <summary>
		/// 미리 정의된 #008B8B 색을 가져옵니다.
		/// </summary>
		public static Color DarkCyan
		{
			get => FromHtml("#008B8B");
		}

		/// <summary>
		/// 미리 정의된 #B8860B 색을 가져옵니다.
		/// </summary>
		public static Color DarkGoldenrod
		{
			get => FromHtml("#B8860B");
		}

		/// <summary>
		/// 미리 정의된 #A9A9A9 색을 가져옵니다.
		/// </summary>
		public static Color DarkGray
		{
			get => FromHtml("#A9A9A9");
		}

		/// <summary>
		/// 미리 정의된 #006400 색을 가져옵니다.
		/// </summary>
		public static Color DarkGreen
		{
			get => FromHtml("#006400");
		}

		/// <summary>
		/// 미리 정의된 #BDB76B 색을 가져옵니다.
		/// </summary>
		public static Color DarkKhaki
		{
			get => FromHtml("#BDB76B");
		}

		/// <summary>
		/// 미리 정의된 #8B008B 색을 가져옵니다.
		/// </summary>
		public static Color DarkMagenta
		{
			get => FromHtml("#8B008B");
		}

		/// <summary>
		/// 미리 정의된 #556B2F 색을 가져옵니다.
		/// </summary>
		public static Color DarkOliveGreen
		{
			get => FromHtml("#556B2F");
		}

		/// <summary>
		/// 미리 정의된 #FF8C00 색을 가져옵니다.
		/// </summary>
		public static Color DarkOrange
		{
			get => FromHtml("#FF8C00");
		}

		/// <summary>
		/// 미리 정의된 #9932CC 색을 가져옵니다.
		/// </summary>
		public static Color DarkOrchid
		{
			get => FromHtml("#9932CC");
		}

		/// <summary>
		/// 미리 정의된 #8B0000 색을 가져옵니다.
		/// </summary>
		public static Color DarkRed
		{
			get => FromHtml("#8B0000");
		}

		/// <summary>
		/// 미리 정의된 #E9967A 색을 가져옵니다.
		/// </summary>
		public static Color DarkSalmon
		{
			get => FromHtml("#E9967A");
		}

		/// <summary>
		/// 미리 정의된 #8FBC8B 색을 가져옵니다.
		/// </summary>
		public static Color DarkSeaGreen
		{
			get => FromHtml("#8FBC8B");
		}

		/// <summary>
		/// 미리 정의된 #483D8B 색을 가져옵니다.
		/// </summary>
		public static Color DarkSlateBlue
		{
			get => FromHtml("#483D8B");
		}

		/// <summary>
		/// 미리 정의된 #2F4F4F 색을 가져옵니다.
		/// </summary>
		public static Color DarkSlateGray
		{
			get => FromHtml("#2F4F4F");
		}

		/// <summary>
		/// 미리 정의된 #00CED1 색을 가져옵니다.
		/// </summary>
		public static Color DarkTurquoise
		{
			get => FromHtml("#00CED1");
		}

		/// <summary>
		/// 미리 정의된 #9400D3 색을 가져옵니다.
		/// </summary>
		public static Color DarkViolet
		{
			get => FromHtml("#9400D3");
		}

		/// <summary>
		/// 미리 정의된 #FF1493 색을 가져옵니다.
		/// </summary>
		public static Color DeepPink
		{
			get => FromHtml("#FF1493");
		}

		/// <summary>
		/// 미리 정의된 #00BFFF 색을 가져옵니다.
		/// </summary>
		public static Color DeepSkyBlue
		{
			get => FromHtml("#00BFFF");
		}

		/// <summary>
		/// 미리 정의된 #696969 색을 가져옵니다.
		/// </summary>
		public static Color DimGray
		{
			get => FromHtml("#696969");
		}

		/// <summary>
		/// 미리 정의된 #1E90FF 색을 가져옵니다.
		/// </summary>
		public static Color DodgerBlue
		{
			get => FromHtml("#1E90FF");
		}

		/// <summary>
		/// 미리 정의된 #B22222 색을 가져옵니다.
		/// </summary>
		public static Color Firebrick
		{
			get => FromHtml("#B22222");
		}

		/// <summary>
		/// 미리 정의된 #FFFAF0 색을 가져옵니다.
		/// </summary>
		public static Color FloralWhite
		{
			get => FromHtml("#FFFAF0");
		}

		/// <summary>
		/// 미리 정의된 #228B22 색을 가져옵니다.
		/// </summary>
		public static Color ForestGreen
		{
			get => FromHtml("#228B22");
		}

		/// <summary>
		/// 미리 정의된 #FF00FF 색을 가져옵니다.
		/// </summary>
		public static Color Fuchsia
		{
			get => FromHtml("#FF00FF");
		}

		/// <summary>
		/// 미리 정의된 #DCDCDC 색을 가져옵니다.
		/// </summary>
		public static Color Gainsboro
		{
			get => FromHtml("#DCDCDC");
		}

		/// <summary>
		/// 미리 정의된 #F8F8FF 색을 가져옵니다.
		/// </summary>
		public static Color GhostWhite
		{
			get => FromHtml("#F8F8FF");
		}

		/// <summary>
		/// 미리 정의된 #FFD700 색을 가져옵니다.
		/// </summary>
		public static Color Gold
		{
			get => FromHtml("#FFD700");
		}

		/// <summary>
		/// 미리 정의된 #DAA520 색을 가져옵니다.
		/// </summary>
		public static Color Goldenrod
		{
			get => FromHtml("#DAA520");
		}

		/// <summary>
		/// 미리 정의된 #808080 색을 가져옵니다.
		/// </summary>
		public static Color Gray
		{
			get => FromHtml("#808080");
		}

		/// <summary>
		/// 미리 정의된 #008000 색을 가져옵니다.
		/// </summary>
		public static Color Green
		{
			get => FromHtml("#008000");
		}

		/// <summary>
		/// 미리 정의된 #ADFF2F 색을 가져옵니다.
		/// </summary>
		public static Color GreenYellow
		{
			get => FromHtml("#ADFF2F");
		}

		/// <summary>
		/// 미리 정의된 #F0FFF0 색을 가져옵니다.
		/// </summary>
		public static Color Honeydew
		{
			get => FromHtml("#F0FFF0");
		}

		/// <summary>
		/// 미리 정의된 #FF69B4 색을 가져옵니다.
		/// </summary>
		public static Color HotPink
		{
			get => FromHtml("#FF69B4");
		}

		/// <summary>
		/// 미리 정의된 #CD5C5C 색을 가져옵니다.
		/// </summary>
		public static Color IndianRed
		{
			get => FromHtml("#CD5C5C");
		}

		/// <summary>
		/// 미리 정의된 #4B0082 색을 가져옵니다.
		/// </summary>
		public static Color Indigo
		{
			get => FromHtml("#4B0082");
		}

		/// <summary>
		/// 미리 정의된 #FFFFF0 색을 가져옵니다.
		/// </summary>
		public static Color Ivory
		{
			get => FromHtml("#FFFFF0");
		}

		/// <summary>
		/// 미리 정의된 #F0E68C 색을 가져옵니다.
		/// </summary>
		public static Color Khaki
		{
			get => FromHtml("#F0E68C");
		}

		/// <summary>
		/// 미리 정의된 #E6E6FA 색을 가져옵니다.
		/// </summary>
		public static Color Lavender
		{
			get => FromHtml("#E6E6FA");
		}

		/// <summary>
		/// 미리 정의된 #FFF0F5 색을 가져옵니다.
		/// </summary>
		public static Color LavenderBlush
		{
			get => FromHtml("#FFF0F5");
		}

		/// <summary>
		/// 미리 정의된 #7CFC00 색을 가져옵니다.
		/// </summary>
		public static Color LawnGreen
		{
			get => FromHtml("#7CFC00");
		}

		/// <summary>
		/// 미리 정의된 #FFFACD 색을 가져옵니다.
		/// </summary>
		public static Color LemonChiffon
		{
			get => FromHtml("#FFFACD");
		}

		/// <summary>
		/// 미리 정의된 #ADD8E6 색을 가져옵니다.
		/// </summary>
		public static Color LightBlue
		{
			get => FromHtml("#ADD8E6");
		}

		/// <summary>
		/// 미리 정의된 #F08080 색을 가져옵니다.
		/// </summary>
		public static Color LightCoral
		{
			get => FromHtml("#F08080");
		}

		/// <summary>
		/// 미리 정의된 #E0FFFF 색을 가져옵니다.
		/// </summary>
		public static Color LightCyan
		{
			get => FromHtml("#E0FFFF");
		}

		/// <summary>
		/// 미리 정의된 #FAFAD2 색을 가져옵니다.
		/// </summary>
		public static Color LightGoldenrodYellow
		{
			get => FromHtml("#FAFAD2");
		}

		/// <summary>
		/// 미리 정의된 #D3D3D3 색을 가져옵니다.
		/// </summary>
		public static Color LightGray
		{
			get => FromHtml("#D3D3D3");
		}

		/// <summary>
		/// 미리 정의된 #90EE90 색을 가져옵니다.
		/// </summary>
		public static Color LightGreen
		{
			get => FromHtml("#90EE90");
		}

		/// <summary>
		/// 미리 정의된 #FFB6C1 색을 가져옵니다.
		/// </summary>
		public static Color LightPink
		{
			get => FromHtml("#FFB6C1");
		}

		/// <summary>
		/// 미리 정의된 #FFA07A 색을 가져옵니다.
		/// </summary>
		public static Color LightSalmon
		{
			get => FromHtml("#FFA07A");
		}

		/// <summary>
		/// 미리 정의된 #20B2AA 색을 가져옵니다.
		/// </summary>
		public static Color LightSeaGreen
		{
			get => FromHtml("#20B2AA");
		}

		/// <summary>
		/// 미리 정의된 #87CEFA 색을 가져옵니다.
		/// </summary>
		public static Color LightSkyBlue
		{
			get => FromHtml("#87CEFA");
		}

		/// <summary>
		/// 미리 정의된 #778899 색을 가져옵니다.
		/// </summary>
		public static Color LightSlateGray
		{
			get => FromHtml("#778899");
		}

		/// <summary>
		/// 미리 정의된 #B0C4DE 색을 가져옵니다.
		/// </summary>
		public static Color LightSteelBlue
		{
			get => FromHtml("#B0C4DE");
		}

		/// <summary>
		/// 미리 정의된 #FFFFE0 색을 가져옵니다.
		/// </summary>
		public static Color LightYellow
		{
			get => FromHtml("#FFFFE0");
		}

		/// <summary>
		/// 미리 정의된 #00FF00 색을 가져옵니다.
		/// </summary>
		public static Color Lime
		{
			get => FromHtml("#00FF00");
		}

		/// <summary>
		/// 미리 정의된 #32CD32 색을 가져옵니다.
		/// </summary>
		public static Color LimeGreen
		{
			get => FromHtml("#32CD32");
		}

		/// <summary>
		/// 미리 정의된 #FAF0E6 색을 가져옵니다.
		/// </summary>
		public static Color Linen
		{
			get => FromHtml("#FAF0E6");
		}

		/// <summary>
		/// 미리 정의된 #FF00FF 색을 가져옵니다.
		/// </summary>
		public static Color Magenta
		{
			get => FromHtml("#FF00FF");
		}

		/// <summary>
		/// 미리 정의된 #800000 색을 가져옵니다.
		/// </summary>
		public static Color Maroon
		{
			get => FromHtml("#800000");
		}

		/// <summary>
		/// 미리 정의된 #66CDAA 색을 가져옵니다.
		/// </summary>
		public static Color MediumAquamarine
		{
			get => FromHtml("#66CDAA");
		}

		/// <summary>
		/// 미리 정의된 #0000CD 색을 가져옵니다.
		/// </summary>
		public static Color MediumBlue
		{
			get => FromHtml("#0000CD");
		}

		/// <summary>
		/// 미리 정의된 #BA55D3 색을 가져옵니다.
		/// </summary>
		public static Color MediumOrchid
		{
			get => FromHtml("#BA55D3");
		}

		/// <summary>
		/// 미리 정의된 #9370DB 색을 가져옵니다.
		/// </summary>
		public static Color MediumPurple
		{
			get => FromHtml("#9370DB");
		}

		/// <summary>
		/// 미리 정의된 #3CB371 색을 가져옵니다.
		/// </summary>
		public static Color MediumSeaGreen
		{
			get => FromHtml("#3CB371");
		}

		/// <summary>
		/// 미리 정의된 #7B68EE 색을 가져옵니다.
		/// </summary>
		public static Color MediumSlateBlue
		{
			get => FromHtml("#7B68EE");
		}

		/// <summary>
		/// 미리 정의된 #00FA9A 색을 가져옵니다.
		/// </summary>
		public static Color MediumSpringGreen
		{
			get => FromHtml("#00FA9A");
		}

		/// <summary>
		/// 미리 정의된 #48D1CC 색을 가져옵니다.
		/// </summary>
		public static Color MediumTurquoise
		{
			get => FromHtml("#48D1CC");
		}

		/// <summary>
		/// 미리 정의된 #C71585 색을 가져옵니다.
		/// </summary>
		public static Color MediumVioletRed
		{
			get => FromHtml("#C71585");
		}

		/// <summary>
		/// 미리 정의된 #191970 색을 가져옵니다.
		/// </summary>
		public static Color MidnightBlue
		{
			get => FromHtml("#191970");
		}

		/// <summary>
		/// 미리 정의된 #F5FFFA 색을 가져옵니다.
		/// </summary>
		public static Color MintCream
		{
			get => FromHtml("#F5FFFA");
		}

		/// <summary>
		/// 미리 정의된 #FFE4E1 색을 가져옵니다.
		/// </summary>
		public static Color MistyRose
		{
			get => FromHtml("#FFE4E1");
		}

		/// <summary>
		/// 미리 정의된 #FFE4B5 색을 가져옵니다.
		/// </summary>
		public static Color Moccasin
		{
			get => FromHtml("#FFE4B5");
		}

		/// <summary>
		/// 미리 정의된 #FFDEAD 색을 가져옵니다.
		/// </summary>
		public static Color NavajoWhite
		{
			get => FromHtml("#FFDEAD");
		}

		/// <summary>
		/// 미리 정의된 #000080 색을 가져옵니다.
		/// </summary>
		public static Color Navy
		{
			get => FromHtml("#000080");
		}

		/// <summary>
		/// 미리 정의된 #FDF5E6 색을 가져옵니다.
		/// </summary>
		public static Color OldLace
		{
			get => FromHtml("#FDF5E6");
		}

		/// <summary>
		/// 미리 정의된 #808000 색을 가져옵니다.
		/// </summary>
		public static Color Olive
		{
			get => FromHtml("#808000");
		}

		/// <summary>
		/// 미리 정의된 #6B8E23 색을 가져옵니다.
		/// </summary>
		public static Color OliveDrab
		{
			get => FromHtml("#6B8E23");
		}

		/// <summary>
		/// 미리 정의된 #FFA500 색을 가져옵니다.
		/// </summary>
		public static Color Orange
		{
			get => FromHtml("#FFA500");
		}

		/// <summary>
		/// 미리 정의된 #FF4500 색을 가져옵니다.
		/// </summary>
		public static Color OrangeRed
		{
			get => FromHtml("#FF4500");
		}

		/// <summary>
		/// 미리 정의된 #DA70D6 색을 가져옵니다.
		/// </summary>
		public static Color Orchid
		{
			get => FromHtml("#DA70D6");
		}

		/// <summary>
		/// 미리 정의된 #EEE8AA 색을 가져옵니다.
		/// </summary>
		public static Color PaleGoldenrod
		{
			get => FromHtml("#EEE8AA");
		}

		/// <summary>
		/// 미리 정의된 #98FB98 색을 가져옵니다.
		/// </summary>
		public static Color PaleGreen
		{
			get => FromHtml("#98FB98");
		}

		/// <summary>
		/// 미리 정의된 #AFEEEE 색을 가져옵니다.
		/// </summary>
		public static Color PaleTurquoise
		{
			get => FromHtml("#AFEEEE");
		}

		/// <summary>
		/// 미리 정의된 #DB7093 색을 가져옵니다.
		/// </summary>
		public static Color PaleVioletRed
		{
			get => FromHtml("#DB7093");
		}

		/// <summary>
		/// 미리 정의된 #FFEFD5 색을 가져옵니다.
		/// </summary>
		public static Color PapayaWhip
		{
			get => FromHtml("#FFEFD5");
		}

		/// <summary>
		/// 미리 정의된 #FFDAB9 색을 가져옵니다.
		/// </summary>
		public static Color PeachPuff
		{
			get => FromHtml("#FFDAB9");
		}

		/// <summary>
		/// 미리 정의된 #CD853F 색을 가져옵니다.
		/// </summary>
		public static Color Peru
		{
			get => FromHtml("#CD853F");
		}

		/// <summary>
		/// 미리 정의된 #FFC0CB 색을 가져옵니다.
		/// </summary>
		public static Color Pink
		{
			get => FromHtml("#FFC0CB");
		}

		/// <summary>
		/// 미리 정의된 #DDA0DD 색을 가져옵니다.
		/// </summary>
		public static Color Plum
		{
			get => FromHtml("#DDA0DD");
		}

		/// <summary>
		/// 미리 정의된 #B0E0E6 색을 가져옵니다.
		/// </summary>
		public static Color PowderBlue
		{
			get => FromHtml("#B0E0E6");
		}

		/// <summary>
		/// 미리 정의된 #800080 색을 가져옵니다.
		/// </summary>
		public static Color Purple
		{
			get => FromHtml("#800080");
		}

		/// <summary>
		/// 미리 정의된 #FF0000 색을 가져옵니다.
		/// </summary>
		public static Color Red
		{
			get => FromHtml("#FF0000");
		}

		/// <summary>
		/// 미리 정의된 #BC8F8F 색을 가져옵니다.
		/// </summary>
		public static Color RosyBrown
		{
			get => FromHtml("#BC8F8F");
		}

		/// <summary>
		/// 미리 정의된 #4169E1 색을 가져옵니다.
		/// </summary>
		public static Color RoyalBlue
		{
			get => FromHtml("#4169E1");
		}

		/// <summary>
		/// 미리 정의된 #8B4513 색을 가져옵니다.
		/// </summary>
		public static Color SaddleBrown
		{
			get => FromHtml("#8B4513");
		}

		/// <summary>
		/// 미리 정의된 #FA8072 색을 가져옵니다.
		/// </summary>
		public static Color Salmon
		{
			get => FromHtml("#FA8072");
		}

		/// <summary>
		/// 미리 정의된 #F4A460 색을 가져옵니다.
		/// </summary>
		public static Color SandyBrown
		{
			get => FromHtml("#F4A460");
		}

		/// <summary>
		/// 미리 정의된 #2E8B57 색을 가져옵니다.
		/// </summary>
		public static Color SeaGreen
		{
			get => FromHtml("#2E8B57");
		}

		/// <summary>
		/// 미리 정의된 #FFF5EE 색을 가져옵니다.
		/// </summary>
		public static Color SeaShell
		{
			get => FromHtml("#FFF5EE");
		}

		/// <summary>
		/// 미리 정의된 #A0522D 색을 가져옵니다.
		/// </summary>
		public static Color Sienna
		{
			get => FromHtml("#A0522D");
		}

		/// <summary>
		/// 미리 정의된 #C0C0C0 색을 가져옵니다.
		/// </summary>
		public static Color Silver
		{
			get => FromHtml("#C0C0C0");
		}

		/// <summary>
		/// 미리 정의된 #87CEEB 색을 가져옵니다.
		/// </summary>
		public static Color SkyBlue
		{
			get => FromHtml("#87CEEB");
		}

		/// <summary>
		/// 미리 정의된 #6A5ACD 색을 가져옵니다.
		/// </summary>
		public static Color SlateBlue
		{
			get => FromHtml("#6A5ACD");
		}

		/// <summary>
		/// 미리 정의된 #708090 색을 가져옵니다.
		/// </summary>
		public static Color SlateGray
		{
			get => FromHtml("#708090");
		}

		/// <summary>
		/// 미리 정의된 #FFFAFA 색을 가져옵니다.
		/// </summary>
		public static Color Snow
		{
			get => FromHtml("#FFFAFA");
		}

		/// <summary>
		/// 미리 정의된 #00FF7F 색을 가져옵니다.
		/// </summary>
		public static Color SpringGreen
		{
			get => FromHtml("#00FF7F");
		}

		/// <summary>
		/// 미리 정의된 #4682B4 색을 가져옵니다.
		/// </summary>
		public static Color SteelBlue
		{
			get => FromHtml("#4682B4");
		}

		/// <summary>
		/// 미리 정의된 #D2B48C 색을 가져옵니다.
		/// </summary>
		public static Color Tan
		{
			get => FromHtml("#D2B48C");
		}

		/// <summary>
		/// 미리 정의된 #008080 색을 가져옵니다.
		/// </summary>
		public static Color Teal
		{
			get => FromHtml("#008080");
		}

		/// <summary>
		/// 미리 정의된 #D8BFD8 색을 가져옵니다.
		/// </summary>
		public static Color Thistle
		{
			get => FromHtml("#D8BFD8");
		}

		/// <summary>
		/// 미리 정의된 #FF6347 색을 가져옵니다.
		/// </summary>
		public static Color Tomato
		{
			get => FromHtml("#FF6347");
		}

		/// <summary>
		/// 미리 정의된 #00000000 색을 가져옵니다.
		/// </summary>
		public static Color Transparent
		{
			get => FromHtml("#00000000");
		}

		/// <summary>
		/// 미리 정의된 #40E0D0 색을 가져옵니다.
		/// </summary>
		public static Color Turquoise
		{
			get => FromHtml("#40E0D0");
		}

		/// <summary>
		/// 미리 정의된 #EE82EE 색을 가져옵니다.
		/// </summary>
		public static Color Violet
		{
			get => FromHtml("#EE82EE");
		}

		/// <summary>
		/// 미리 정의된 #F5DEB3 색을 가져옵니다.
		/// </summary>
		public static Color Wheat
		{
			get => FromHtml("#F5DEB3");
		}

		/// <summary>
		/// 미리 정의된 #FFFFFF 색을 가져옵니다.
		/// </summary>
		public static Color White
		{
			get => FromHtml("#FFFFFF");
		}

		/// <summary>
		/// 미리 정의된 #F5F5F5 색을 가져옵니다.
		/// </summary>
		public static Color WhiteSmoke
		{
			get => FromHtml("#F5F5F5");
		}

		/// <summary>
		/// 미리 정의된 #FFFF00 색을 가져옵니다.
		/// </summary>
		public static Color Yellow
		{
			get => FromHtml("#FFFF00");
		}

		/// <summary>
		/// 미리 정의된 #9ACD32 색을 가져옵니다.
		/// </summary>
		public static Color YellowGreen
		{
			get => FromHtml("#9ACD32");
		}
    }
}
