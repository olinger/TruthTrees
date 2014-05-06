TruthTrees
==========

GUI for truth tree creation and verification

Requirements:
- Python 2.7
- Sympy
- .NET Framework 4.0

Keyboard Shortcuts:

|   Button   |  Shortcut  |
|------------|------------|
|Premise     |Ctrl-P      |
|Level 		   |Ctrl-A      |
|Branch		   |Ctrl-B      |
|Verify		   |Ctrl-V      |
|Closed   	 |Ctrl-X      |
|Open 		   | Ctrl-O     |
|Delete 	   |Ctrl-D      |
|Clear All   |Ctrl-Shift-D|
|And 		     |   &        |
|Or 			   | &#124;     |
|Not			   |  ~         |
|Conditional |   $        |
Biconditional|   %        |



Known Issues:

- Verify Tree button and Delete button currently not implemented (had too many bugs, so I disabled them)

- Save file dialog not implemented

- To clear the tree use ctrl-shift D or use ctrl-D on the parent node.

- If you accidentally add a node you currently can't delete it but you can ignore it and make new nodes and the tree will still work.

- Branches will possibly overlap, position is currently static after nodes are created

- Negation of biconditional will not work

- When you create the first textbox you will have to type the first character twice or click twice before typing
