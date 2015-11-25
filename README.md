Micro library inspired by F# single case discirminated unions.

Create primitive domain concepts in C# with one line.

	class Age : CaseOf<int, Age> {}

Pass around instances worry free, they are immutable and implement value based equality.

	var hisAge = Age.New(23);
	var herAge = Age.New(23);

	Assert.IsTrue(herAge.Equals(hisAge));

Implicit downcasting to wrapped typed.

	int integerHisAge = hisAge;
	int integerHerAge = herAge.Value;

	Assert.IsTrue(integerHisAge.Equals(integerHerAge));

Create Action<> or Func<> delegates that are descriptive.

	class Username : CaseOf<string, Name> {}
	class Email : CaseOf<string, Email> {}

	Action<Username, Email> register = (name, email) => { /* .... */ }



Available on Nuget or direct embedding (just copy CaseOf.cs file to your project)