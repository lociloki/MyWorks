

/* 

Write a class class AlienLanguageTranslator that implements all the funcionality of the given
LanguageTranslator class. You will need to override all the methods given in the LanguageTranslator
interface.

*/

public class AlienLanguageTranslator implements LanguageTranslator {
    	// Translates the language from default language

	public String fromDefaultLanguage(String languageTokens){
		String result = "";
	    for(short i = 0; i < languageTokens.length();i++)
	    	result = result + (char)((int)languageTokens.charAt(i) + 3);
	    return result;
	    
	}
	
	// Translates the language to default language
	public String toDefaultLanguage(String languageTokens){
		String result = "";
	    for(short i = 0; i < languageTokens.length();i++)
	    	result = result + (char)((int)languageTokens.charAt(i) - 3);
	    return result;
	}
}

