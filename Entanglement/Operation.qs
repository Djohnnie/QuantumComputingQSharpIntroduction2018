namespace Quantum.Entanglement
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

    operation Entangle () : (Bool, Bool)
    {
        body
        {
            mutable result = (false,false);
			using(register = Qubit[2])
			{
				let q1 = register[0];
				let q2 = register[1];

				H(q2);
				CNOT(q2,q1);

				let b1 = M(q1);
				let b2 = M(q2);

				set result = (b1 == One, b2 == One);

				Reset(b1, q1, b2, q2);
			}
			return result;
        }
    }

	operation Reset(b1: Result, q1: Qubit, b2: Result, q2: Qubit) : ()
	{
		body
		{
			if(b1 == One)
			{
				X(q1);
			}
			if(b2 == One)
			{
				X(q2);
			}
		}		
	}
}
