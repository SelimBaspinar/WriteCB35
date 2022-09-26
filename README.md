# WriteCB35
It is a library written for read and write memory operations. You can make your game cheat codes with the help of this library.

## Read Sample Coding;
### `Me.Text = ReadPointerInteger(Game's Task Manager Name, &HPointer,&HOffset).ToString()`
### `Me.Text = ReadPointerInteger("ac_client", &HB71A38,&H540).ToString()`
### If There Are More Than One OffSet (Write From Large to Small). In other words, the first offset will be at the end, and the next offset will be the previous offset.
### ` Me.Text = ReadPointerInteger("ac_client", &HB71A38,&H14,&H0).ToString()`
### If Offset is More than One;
### `Me.Text = ReadPointerInteger("ac_client", &HB71A38,&H378,&H14,&H0).ToString()`
## Write Sample Coding;
### `WritePointerInteger(Game's Task Manager Name,&HPointer,Value(Deger),&HOffset)`
### `WritePointerInteger("ac_client",&HB71A38,1000,&H540)`
### If Offset is More than One
### `WritePointerInteger("gta_sa",&HB71A38,1000,&H378, &H14,&H0)`
