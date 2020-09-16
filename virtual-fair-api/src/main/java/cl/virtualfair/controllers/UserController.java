package cl.virtualfair.controllers;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import cl.virtualfair.models.virtualfair.EventLog;
import cl.virtualfair.models.virtualfair.SessionToken;
import cl.virtualfair.models.virtualfair.User;
import cl.virtualfair.services.virtualfair.EventLogService;
import cl.virtualfair.services.virtualfair.SessionTokenService;
import cl.virtualfair.services.virtualfair.UserService;

@RestController
@RequestMapping("/api/User/")
@CrossOrigin
public class UserController {

	@Autowired
	private UserService userService;
	
	@Autowired
	private SessionTokenService sessionTokenService;
	
	@Autowired
	private EventLogService eventLogService;

	@GetMapping("findAll")
	public ResponseEntity<Map<String, Object>> findAll(@RequestHeader(name = "Authorization", required = true)String token, @RequestParam(name = "searcher", required = false)String searcher, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				List<User> users = userService.findAll(searcher);
				
				if(users.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("users", users);
					map.put("countRows", users.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("users", users);
					map.put("countRows", users.size());
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
				}
				
			}else {

				map.put("message", "Token no Permitido.");
				map.put("statusCode", HttpStatus.FORBIDDEN.value());
			
				return ResponseEntity.ok().body(map);
				
			}
			
		}catch(Exception exception) {
			
			EventLog eventLog = new EventLog();
			
			eventLog.setIdEventType(2);
			eventLog.setHost(httpServletRequest.getRemoteAddr());
			eventLog.setHttpMethod(httpServletRequest.getMethod());
			eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
			eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
			eventLog.setMessage(exception.getMessage());
			
			eventLogService.create(eventLog);
			
			map.put("message", exception.getMessage());
			map.put("statusCode", HttpStatus.INTERNAL_SERVER_ERROR.value());
			
			return ResponseEntity.ok().body(map);
			
		}
	}
	
	@PostMapping("findByEmailAndPassword")
	public ResponseEntity<Map<String, Object>> findByEmailAndPassword(@RequestBody User user, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			if(user.getEmail() == null || user.getEmail().isEmpty()) {

				map.put("message", "The Email is Required.");
				map.put("statusCode", HttpStatus.NO_CONTENT.value());
			
				return ResponseEntity.ok().body(map);
				
			}else if(user.getPassword() == null || user.getPassword().isEmpty()) {

				map.put("message", "The Password is Required.");
				map.put("statusCode", HttpStatus.NO_CONTENT.value());
			
				return ResponseEntity.ok().body(map);
				
			}else {
			
				User userExisting = userService.findByEmailAndPassword(user.getEmail(), user.getPassword());
				
				if(userExisting != null) {

					if(userExisting.getStatus() == 1) {
					
						SessionToken sessionToken = new SessionToken();
						
						sessionToken.setIdUser(userExisting.getId());
						sessionToken.setHost(httpServletRequest.getRemoteAddr());
						
						sessionToken = sessionTokenService.create(sessionToken);
			
						EventLog eventLog = new EventLog();
						
						eventLog.setIdEventType(1);
						eventLog.setIdUser(sessionToken.getIdUser());
						eventLog.setHost(httpServletRequest.getRemoteAddr());
						eventLog.setHttpMethod(httpServletRequest.getMethod());
						eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
						eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
						
						eventLogService.create(eventLog);
						
						map.put("userConnect", userExisting);
						map.put("sessionToken", sessionToken);
						map.put("statusCode", HttpStatus.OK.value());
						
						return ResponseEntity.ok().body(map);
						
					}else {

						map.put("message", "Usuario inhabilitado.");
						map.put("statusCode", HttpStatus.FORBIDDEN.value());
					
						return ResponseEntity.ok().body(map);
					}
					
				}else {
					
					map.put("message", "Usuario no existe.");
					map.put("statusCode", HttpStatus.FORBIDDEN.value());
				
					return ResponseEntity.ok().body(map);
				}
				
			}
			
		}catch(Exception exception) {
			
			EventLog eventLog = new EventLog();
			
			eventLog.setIdEventType(2);
			eventLog.setHost(httpServletRequest.getRemoteAddr());
			eventLog.setHttpMethod(httpServletRequest.getMethod());
			eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
			eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
			eventLog.setMessage(exception.getMessage());
			
			eventLogService.create(eventLog);
			
			map.put("message", exception.getMessage());
			map.put("statusCode", HttpStatus.INTERNAL_SERVER_ERROR.value());
			
			return ResponseEntity.ok().body(map);
			
		}
		
	}
}
