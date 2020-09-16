package cl.virtualfair.services.virtualfair;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.User;
import cl.virtualfair.repositories.IUserRepository;
import cl.virtualfair.services.other.SecurityPasswordService;

@Service
public class UserService {

	@Autowired
	private IUserRepository iUserRepository;
	
	@Autowired
	private SecurityPasswordService securityPasswordService;
	
	public UserService() {
		
	}
	
	public List<User> findAll(String searcher){
		
		List<User> users = new ArrayList<User>();

		if(searcher == null || searcher.isEmpty()) {
			
			users = iUserRepository.findAll();
			
		}else {
			
			users = iUserRepository.findAll(searcher);
			
		}
		
		return users;
	}
	
	public User findByEmailAndPassword(String email, String password) {
		
		User user = iUserRepository.findByEmail(email);

		if(user != null) {
			
			
			String passwordDescrypt = securityPasswordService.descrypt(user.getPassword());
			
			if(!passwordDescrypt.equals(password)) {
				
				user = null;
				
			}
			
		}
		
		return user;
		
	}
	
	public User findById(long id) {
		
		User user = iUserRepository.findById(id);
		
		return user;
		
	}
}
