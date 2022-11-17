---------------
1. If a _C# script_ <strong><span style="color:tomato">REQUIRES</span></strong> a certain <span style="color:aquamarine;">component</span> to work, you can use the following excerpt to <span style="color:Gold;">AUTOMATICALLY ADD THE COMPONENT!!!</span> 
	+ Put on right above `public class`
```C#
// Template: This comes with Unity
[RequireComponent(typeof(COMPONENT_NAME_HERE))]
```

+ <span style="color:Gold;">EXAMPLE:</span>
```C#
	// Example
	[RequireComponent(typeof(NavMeshAgent))]
	public class EnemyControl : MonoBehaviour
	{
	```

--------------------------

