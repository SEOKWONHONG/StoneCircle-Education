//c, c++ include<stdio.h>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession1 {	
	class Program {
		
		//프로그램 진입점
		static void Main(string[] args) {
			//value type
			int i = 1;
			int j = i;
			Console.WriteLine(" i : {0}, j : {1} ", i, j);
			
			j = 2;			

			Console.WriteLine(" i : {0}, j : {1} ", i, j);

			//reference type
			DrawBase.Point point = new DrawBase.Point(10, 10);

			Console.WriteLine("Point x : {0}, y : {1}", point.x, point.y);

			DrawBase.Point point2 = point;
			point.x = 20;
			point.y = 20;

			Console.WriteLine("Point2 x : {0}, y : {1}", point2.x, point2.y);

			Console.WriteLine("int size(byte) : {0}", sizeof(int));
			Console.WriteLine("double size(byte) : {0}", sizeof(double));
			Console.WriteLine("float size(byte) : {0}", sizeof(float));
			Console.WriteLine("decimal size(byte) : {0}", sizeof(decimal));

			Console.ReadLine();
		}
	}

	namespace DrawBase {
		public class Point {
			public int x;
			public int y;

			public Point (int x, int y) {
				this.x = x;
				this.y = y;
			}
		}
	}
}
