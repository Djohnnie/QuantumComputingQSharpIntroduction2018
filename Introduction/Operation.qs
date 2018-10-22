namespace Quantum.Introduction
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

    operation BitFlip (input: Bool) : (Bool)
    {
        body
        {
			mutable result = false;
            using(register = Qubit[1])
			{
				let q = register[0];
				if(input){
					X(q);
				}

				X(q);

				let b = M(q);
				set result = b == One;

				if(b == One){
					X(q);
				}
			}

			return result;
        }
    }

	operation Hadamard (input: Bool) : (Bool)
    {
        body
        {
			mutable result = false;
            using(register = Qubit[1])
			{
				let q = register[0];
				if(input){
					X(q);
				}

				H(q);

				let b = M(q);
				set result = b == One;

				if(b == One){
					X(q);
				}
			}

			return result;
        }
    }
}