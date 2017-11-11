using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5 {
     class Program {
		static void Main (string[] args) {
			Console.WriteLine("=================Point====================");
			//소멸자를 호출하고 있습니다.
			Point p1 = new Point(10, 10);
			Console.WriteLine(p1.ToString());
			Console.WriteLine(p1.Sum());
			//p1.Dispose();
						
			//소멸자를 호출하지 않고 있습니다.
			//stream, filestream, dbconnection, image, 
			using (Point p2 = new Point(20, 120)) {
				Console.WriteLine(p2.ToString());
				Console.WriteLine(p2.Sum());				
			}

			Console.WriteLine("=================PointEx====================");
			using (PointEx pEx1 = new PointEx()) {
				Console.WriteLine(pEx1.ToString());
				Console.WriteLine(pEx1.Sum());
				Console.WriteLine(pEx1.Mul());
			}

			PointEx pEx2 = new PointEx(100, 100);
			Console.WriteLine(pEx2.ToString());
			Console.WriteLine(pEx2.Sum());
			Console.WriteLine(pEx2.Mul(10));

			Console.WriteLine("=================Loop====================");
			PointEx[] pointArray = new PointEx[10];

			for(int i=0; i<pointArray.Length; i++) {
				pointArray[i] = new PointEx(1, 1);
				pointArray[i].X = (i + 1) * 2;
				pointArray[i].Y = (i + 1) * 4;
				//pointArray[i].SumResult = 0;

				Point p = (Point)pointArray[i];
				Point p11 = pointArray[i] as Point;

				if(p == null) {
					throw new Exception("Point is null.");
				}

				Console.WriteLine("idx : {0}, sumResult : {1} ", i, p.Min());
			}

			Console.ReadLine();
		}
	}

	//public : 모든 외부에
	//private : 내부만 
	//protected : 상속된 객체에만
	//internal : 같은 어셈블리에만	

	public class Point : IDisposable {
		//속성 (property)	
		//함수형으로 실행.	
		//private int _x;
		public int X { get; set; }
		public int Y { get; set; }

		//생성자
		public Point () {
			//initialize
		}

		public Point(int x, int y) {
			//initialize
			Console.WriteLine("Call Constructor");
			this.X = x; this.Y = y;			
		}

		//Finalize
		~Point () {			
			Console.WriteLine("Call Destructor");
		}

		//오버라이딩 할 수 있도록 선언
		public virtual int Sum() {
			return X + Y;
		}

		public virtual int Min() {
			return X - Y;
		}

		protected void Execute() {

		}
				
		public override string ToString () {
			//return base.ToString();			
			return string.Format("X : {0}, Y : {1}", this.X, this.Y);
		}

		public virtual void Dispose () {
			Console.WriteLine("Call Dispose");
						
			//소멸자(Finalize)를 호출하지 않게 한다. 
			//왜??? Dispose를 명시적으로 구현해서 소멸자가 호출하기 전에, 즉 객체가 해제되지 전에 관리되는(Managed) 객체를 해제하기 위함이다.
			//FileStream, DbConnection
			GC.SuppressFinalize(this);
			GC.Collect();
		}
	}

	public class PointEx : Point {
		public PointEx() : base (20, 20) { Console.WriteLine("Call Constructor PointEx"); }
		public PointEx(int x, int y){
			Console.WriteLine("Call Constructor PointEx");
			this.X = x; this.Y = y;
		}

		//Finalize
		~PointEx () {
			Console.WriteLine("Call Destructor PointEx");
		}

		//오버라이딩 (재정의)
		public override int Sum () {
			return base.Sum() + 1;			
		}
				
		public int Mul() {
			return this.Sum() * 4;
		}

		//오버로딩 (확장)
		public int Mul(int n) {
			return this.Sum() * n;
		}

		public int Mul (string n) {
			return this.Sum() * n.Length;
		}

		//오버로딩 (확장)
		public int Mul (int n, int m) {			
			return this.Sum() * n;
		}

		public override string ToString () {
			return base.ToString();
			//return string.Format("Ex X : {0}, Y : {1}", this.X, this.Y);
		}

		public override void Dispose () {
			base.Dispose();

		}
	}

    internal class PointExEx : PointEx {

	}
}
