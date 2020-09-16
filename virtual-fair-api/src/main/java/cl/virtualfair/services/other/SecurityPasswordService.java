package cl.virtualfair.services.other;

import java.nio.charset.StandardCharsets;
import java.util.Base64;

import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;

import org.springframework.stereotype.Service;

@Service
public class SecurityPasswordService {

	public SecurityPasswordService() {
		
		
	}
	
	public String encrypt(String plainText) {
		
		String encryptText = null;
		
		try {
			
			Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5PADDING");
			
			byte[] key = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
			
			SecretKeySpec secretKeySpec = new SecretKeySpec(key, "AES");
			
			cipher.init(Cipher.ENCRYPT_MODE, secretKeySpec);
			
			encryptText = Base64.getEncoder().encodeToString(cipher.doFinal(plainText.getBytes(StandardCharsets.UTF_8)));
			
			return encryptText;
			
		}catch(Exception exception) {
			
			return encryptText;
			
		}
		
	}

	public String descrypt(String encryptText) {
		
		String plainText = null;
		
		try {
			
			Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5PADDING");
			
			byte[] key = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
			
			SecretKeySpec secretKeySpec = new SecretKeySpec(key, "AES");
			
			cipher.init(Cipher.DECRYPT_MODE, secretKeySpec);
			
			plainText = new String(cipher.doFinal(Base64.getDecoder().decode(encryptText)));
			
			return plainText;
			
		}catch(Exception exception){
		
			return plainText;
			
		}
		
	}
}
