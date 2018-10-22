namespace Quantum.Deutsch
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

	// qOutput:  |0> --- --- --- --- |0>
	// qInput :  |x> --- --- --- --- |x>
    operation ConstantZero (qOutput: Qubit, qInput: Qubit) : ()
    {
        body
        {
            
        }
    }

	// qOutput:  |0> --- --- -X- --- |1>
	// qInput :  |x> --- --- --- --- |x>
    operation ConstantOne (qOutput: Qubit, qInput: Qubit) : ()
    {
        body
        {
            X(qOutput);
        }
    }

	// qOutput:  |0> --- -O- --- --- |x>
	// qInput :  |x> --- -|- --- --- |x>
    operation Identity (qOutput: Qubit, qInput: Qubit) : ()
    {
        body
        {
            CNOT(qInput, qOutput);
        }
    }

	// qOutput:  |0> --- -O- -X- --- |!x>
	// qInput :  |x> --- -|- --- ---  |x>
    operation Negation (qOutput: Qubit, qInput: Qubit) : ()
    {
        body
        {
            CNOT(qInput, qOutput);
            X(qOutput);
        }
    }

	operation DeutschTestConstantZero():(Bool, Bool)
	{
		body
		{
			mutable result = (false, false);
			using(register = Qubit[2])
			{
				let qOutput = register[0];
				let qInput = register[1];

				X(qOutput);
				X(qInput);

				H(qOutput);
				H(qInput);

				ConstantZero(qOutput, qInput);
				
				H(qOutput);
				H(qInput);

				let bOutput = M(qOutput);
				let bInput = M(qInput);

				set result = (bInput == One, bOutput == One);

				Reset(bOutput, qOutput, bInput, qInput);
			}

			return result;
		}
	}

	operation DeutschTestConstantOne():(Bool, Bool)
	{
		body
		{
			mutable result = (false, false);
			using(register = Qubit[2])
			{
				let qOutput = register[0];
				let qInput = register[1];

				X(qOutput);
				X(qInput);

				H(qOutput);
				H(qInput);

				ConstantOne(qOutput, qInput);
				
				H(qOutput);
				H(qInput);

				let bOutput = M(qOutput);
				let bInput = M(qInput);

				set result = (bInput == One, bOutput == One);

				Reset(bOutput, qOutput, bInput, qInput);
			}

			return result;
		}
	}

	operation DeutschTestIdentity():(Bool, Bool)
	{
		body
		{
			mutable result = (false, false);
			using(register = Qubit[2])
			{
				let qOutput = register[0];
				let qInput = register[1];

				X(qOutput);
				X(qInput);

				H(qOutput);
				H(qInput);

				Identity(qOutput, qInput);
				
				H(qOutput);
				H(qInput);

				let bOutput = M(qOutput);
				let bInput = M(qInput);

				set result = (bInput == One, bOutput == One);

				Reset(bOutput, qOutput, bInput, qInput);
			}

			return result;
		}
	}

	operation DeutschTestNegation():(Bool, Bool)
	{
		body
		{
			mutable result = (false, false);
			using(register = Qubit[2])
			{
				let qOutput = register[0];
				let qInput = register[1];

				X(qOutput);
				X(qInput);

				H(qOutput);
				H(qInput);

				Negation(qOutput, qInput);
				
				H(qOutput);
				H(qInput);

				let bOutput = M(qOutput);
				let bInput = M(qInput);

				set result = (bInput == One, bOutput == One);

				Reset(bOutput, qOutput, bInput, qInput);
			}

			return result;
		}
	}

	operation Reset(bOutput: Result, qOutput: Qubit, bInput: Result, qInput: Qubit) : ()
	{
		body
		{
			if(bOutput == One)
			{
				X(qOutput);
			}
			if(bInput == One)
			{
				X(qInput);
			}
		}		
	}
}