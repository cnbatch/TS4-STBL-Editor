**16** Changes:
 - Reworked main menu 
 - Added test functional to add STBL objects into the .package file.
 - Reworked save functional to allow future changes for adding STBL into the packages.
 - Added a new functional "Create a new STBL file in .package file" in the main menu of the MainUI - to create a new STBL record in .package file.

**15** Changes:
 - Fixed bug, when STBL with count of element = 0 was not saved.
 - Now packages and STBL files are properly closed, when a new one opened in the same app session.
 - Now it's possible to drag and drop on the programm not only STBL files, but .PACKAGE files too.
 - Added a new Link Label on main form - it will be showed, when .package file was open. This Link Label will allow you to open another STBL element from opened .package file. 
 - In Editor you will be able to use Delete button on keyboard for deletion of the rows.
 - Added a new functional "New SBTL File" in the main menu of the MainUI - to create a new .stbl file

**14** - Now it's possible to open STBL and PACKAGE files with TS4-STBL-Editor via Windows command "Open With ...".
Fixed elements on Editor window.
Now it's possible to open STBL and PACKAGE files with TS4-STBL-Editor via Windows command "Open With ..."

**12** - Package Files - Mass insert of copied values.
Now it's possible to delete many of selected string rows at time, not only one row per deletion.

Added a new one File menu item "Package Files - Mass insert of copied values" - to paste copied values into the STBL objects of the .package file.

CTRL+A to select all STBL items from .package file.

**11** - Added base version of the editor with s4pi to edit STBL files directly from .package files.

**10.2**: Improved Mass Insert - now it will not create duplicates with same IDs, but will update str values of the existing strings.

**V. 10.1** - Reworked context menu - more usable for editing cells in Editor

**10.0**: Added new features for Editor form:
 - press CTRL+S and form will apply changes and will close (equal to OK button);
 - press ESC key on keyboard and form will close (equal to CANCEL button);
 - added context menu, that will appears when clicked on some cell in Editor:
 - - deleteThisElement - will delete current row
 - - Copy_selected_rows - will copy current cells row

**9.0** - Added option for mass insert of string values into multiple files. After closing Editor window, scroll dataGridView1 to the end, to be convinced, that new rows were added...

**8.0** - GUI improvements - now program show language of the opened file.
Added help window with lang codes list.

**7.0** - Drag&Drop files on Main form is enabled - just Drag&Drop files on program to open it!

**6.0** - Added option to copy values by entering those ids.
