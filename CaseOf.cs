using System;

namespace CaseOf
{
	public abstract class CaseOf<T, V>
		where V : CaseOf<T, V>, new()
	{
		private T val;

		public static V New(T val) {
			return new V() { Value = val };
		}

		public virtual T Value 
		{ 
			get { return val; } 
			protected set 
			{
				if (value == null) {
					throw new ArgumentNullException(string.Format("{0} Value", typeof(V).Name));
				}
				val = value; 
			}  
		}

		public static implicit operator T (CaseOf<T, V> self) 
		{
			return self.Value;
		}

		public override bool Equals (object obj)
		{
			var objV = obj as V;
			return objV != null && this.Value.Equals(objV.Value);
		}

		public override int GetHashCode ()
		{
			return Value.GetHashCode ();
		}
	}
}

