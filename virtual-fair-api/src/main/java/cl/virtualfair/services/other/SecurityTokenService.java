package cl.virtualfair.services.other;

import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.security.SecureRandom;

import org.springframework.stereotype.Service;

@Service
public class SecurityTokenService {

	public SecurityTokenService() {
		
	}
	
	public String generate(String text) {
		
	    String generatedPassword = null;
	    
	    try {
	    	
	        MessageDigest messageDigest = MessageDigest.getInstance("SHA-512");
	        
	        SecureRandom random = new SecureRandom();
	        byte[] salt = new byte[16];
	        
	        random.nextBytes(salt);
	        
	        messageDigest.update(salt);
	        
	        byte[] bytes = messageDigest.digest(text.getBytes(StandardCharsets.UTF_8));
	        
	        StringBuilder stringBuilder = new StringBuilder();
	        
	        for(int i=0; i< bytes.length ;i++){
	        	
	        	stringBuilder.append(Integer.toString((bytes[i] & 0xff) + 0x100, 16).substring(1));
	        }
	        
	        generatedPassword = stringBuilder.toString();
	        
	        return generatedPassword;
	        
	    } catch (Exception exception) {
	    	
	        return generatedPassword;
	        
	    }		
	}
}
