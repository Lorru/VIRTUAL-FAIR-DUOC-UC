package cl.virtualfair.services.virtualfair;

import java.time.LocalDateTime;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.SessionToken;
import cl.virtualfair.models.virtualfair.User;
import cl.virtualfair.repositories.ISessionTokenRepository;
import cl.virtualfair.services.other.SecurityTokenService;

@Service
public class SessionTokenService {

	@Autowired
	private ISessionTokenRepository iSessionTokenRepository;
	
	@Autowired
	private UserService userService;
	
	@Autowired
	private SecurityTokenService securityTokenService;
	
	public SessionTokenService() {
		
	}
	
	public SessionToken findByTokenAndHost(String token, String host) {
		
		SessionToken sessionToken = iSessionTokenRepository.findByTokenAndHost(token, host);
		
		if(sessionToken != null) {
			
			LocalDateTime dateNow = LocalDateTime.now();
			
			if(sessionToken.getExpirationDate().compareTo(dateNow) < 0) {
				
				sessionToken = null;
				
			}
			
		}
		
		return sessionToken;
		
	}
	
	public SessionToken create(SessionToken sessionToken) {
		
		User user = userService.findById(sessionToken.getIdUser());
		
		sessionToken.setCreationDate(LocalDateTime.now());
		sessionToken.setExpirationDate(LocalDateTime.now().plusMinutes(30));
		
        String token = securityTokenService.generate(sessionToken.getCreationDate().toString()).toLowerCase() + "." +
                securityTokenService.generate(sessionToken.getHost()).toLowerCase() + "." + 
                securityTokenService.generate(sessionToken.getExpirationDate().toString()).toLowerCase() + "." +
                securityTokenService.generate(user.getEmail()).toLowerCase();
		
        sessionToken.setToken(token);
        
		sessionToken = iSessionTokenRepository.save(sessionToken);
		
		return sessionToken;
	}
}
