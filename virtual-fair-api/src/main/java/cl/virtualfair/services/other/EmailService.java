package cl.virtualfair.services.other;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.stereotype.Service;

@Service
public class EmailService {

	@Autowired
	private JavaMailSender javaMailSender;
	
	public EmailService() {
		
	}
	
	public Boolean sendEmail(String to, String subject, String message) {
		
		Boolean result = false;
		
		SimpleMailMessage simpleMailMessage = new SimpleMailMessage(); 
		
		simpleMailMessage.setTo(to); 
		simpleMailMessage.setSubject(subject); 
		simpleMailMessage.setText(message);
		
		javaMailSender.send(simpleMailMessage);
		
		result = true;
		
		return result;
	}
}
