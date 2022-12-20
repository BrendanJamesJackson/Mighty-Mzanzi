mergeInto(LibraryManager.library,
{
	CheckOrientation : function()
	{
		var mql = window.matchMedia("(orientation: landscape)");
		var CorrectOrient;
		if (mql.matches)
		{
			CorrectOrient = "true";
			console.log("JS landscape");
		}
		else
		{
			CorrectOrient = "false";
			console.log("JS portrait");
		}

		var buffer = _malloc(lengthBytesUTF8(CorrectOrient) + 1);
		writeStringToMemory(CorrectOrient, buffer);
		return buffer;
	},
});