Domain is used for many things
1- Entities with some best practices:
	a- always initialize ICollection in the constructor
	b- make it private setter
	c- use value object whenever it is possible(consider configuring it in the Dbcontext configuration)
	d- never use data annotations

2- ValueObjects with specific Conditions:
	a- Add behaviors to a group of related attributes
	b- validate Data stored inside it.
	c- avoid using bad solutions Such as 
		(Creating aSpecific Entity for it or 
			make the as separate attributes)

3- Exceptions will be thrown by Value object incase of Validation error in it.
	