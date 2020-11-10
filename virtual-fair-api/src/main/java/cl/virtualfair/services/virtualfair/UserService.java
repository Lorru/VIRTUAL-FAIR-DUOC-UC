package cl.virtualfair.services.virtualfair;

import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

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

	public User findByEmail(String email) {
		
		User user = iUserRepository.findByEmail(email);
		
		return user;
		
	}
	
	public User findById(long id) {
		
		User user = iUserRepository.findById(id);
		
		return user;
		
	}
	
	public User create(User user) {
		
		user.setPassword(securityPasswordService.encrypt(user.getPassword()));
		
		user.setStatus(1);
		
		user = iUserRepository.save(user);
		
		return user;
		
	}
	
	public User updateById(User user) throws IllegalArgumentException, IllegalAccessException, NoSuchFieldException, SecurityException {
		
		long id = user.getId();
		
		User userExisting = iUserRepository.findById(id);
		
		List<Field> fields = Arrays.stream(userExisting.getClass().getDeclaredFields()).filter(x -> 
								x.getName() != "serialVersionUID" && 
								x.getName() != "Id" && 
								x.getName() != "Password" && 
								x.getName() != "Status" &&
								x.getName() != "Profile"
								).collect(Collectors.toList());
		
		for (Field field : fields) {
		
			Field fieldObject = user.getClass().getDeclaredField(field.getName());
			
			fieldObject.setAccessible(true);
			field.setAccessible(true);
			
			field.set(userExisting, fieldObject.get(user));
		}
		
		userExisting = iUserRepository.save(userExisting);
		
		return userExisting;
		
	}
	
	public User updateStatusById(long id) {
		
		User user = iUserRepository.findById(id);
		
		int status = user.getStatus();
		
		status = status == 1 ? 0 : 1;
		
		user.setStatus(status);
		
		user = iUserRepository.save(user);
		
		return user;
		
	}
}
