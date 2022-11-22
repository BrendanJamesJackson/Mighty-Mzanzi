mergeInto(LibraryManager.library, 
{
	BrowserGetLinkHREF : function()
	{

		var search = window.location.href;
		var searchLen = lengthBytesUTF8(search) + 1;
		var buffer = _malloc(searchLen);
		stringToUTF8(search, buffer, searchLen);
		return  buffer;
	},
});