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
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
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
import io.swagger.annotations.ApiOperation;

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

	@ApiOperation(value = "Servicio para obtener una lista de todos los usuarios")
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
	
	@ApiOperation(value = "Servicio para autenticarse y para obtener el token y el usuario")
	@PostMapping("findByEmailAndPassword")
	public ResponseEntity<Map<String, Object>> findByEmailAndPassword(@RequestBody User user, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			if(user.getEmail() == null || user.getEmail().isEmpty()) {

				map.put("message", "La contraseña es requerida.");
				map.put("statusCode", HttpStatus.NO_CONTENT.value());
			
				return ResponseEntity.ok().body(map);
				
			}else if(user.getPassword() == null || user.getPassword().isEmpty()) {

				map.put("message", "La clave es requerida.");
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
					
					map.put("message", "Credenciales incorrectas.");
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
	
	@ApiOperation(value = "Servicio para crear un nuevo usuario")
	@PostMapping("create")
	public ResponseEntity<Map<String, Object>> create(@RequestHeader(name = "Authorization", required = true)String token, @RequestBody User user, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User userExisting = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && userExisting  != null && userExisting.getIdProfile() == 1 && userExisting.getStatus() == 1) {
			
				if(user.getIdProfile() == null) {
					
					map.put("message", "El IdProfile es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(user.getFullName() == null || user.getFullName().isEmpty()) {
					
					map.put("message", "El FullName es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(user.getCountry() == null || user.getCountry().isEmpty()) {
					
					map.put("message", "El Country es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(user.getCity() == null || user.getCity().isEmpty()) {
					
					map.put("message", "El City es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(user.getAddress() == null || user.getAddress().isEmpty()) {
					
					map.put("message", "El Address es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(user.getEmail() == null || user.getEmail().isEmpty()) {
					
					map.put("message", "El Email es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(user.getPassword() == null || user.getPassword().isEmpty()) {
					
					map.put("message", "El Password es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {
				
					User userExistingEmail = userService.findByEmail(user.getEmail());
					
					if(userExistingEmail == null) {
						
						user = userService.create(user);
						
						if(user != null && user.getId() != 0) {
							
							EventLog eventLog = new EventLog();
							
							eventLog.setIdEventType(1);
							eventLog.setIdUser(sessionToken.getIdUser());
							eventLog.setHost(httpServletRequest.getRemoteAddr());
							eventLog.setHttpMethod(httpServletRequest.getMethod());
							eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
							eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
							
							eventLogService.create(eventLog);
							
							map.put("message", "El usuario se ha registrado con éxito.");
							map.put("statusCode", HttpStatus.CREATED.value());
						
							return ResponseEntity.ok().body(map);
							
						}else {

							map.put("message", "Hubo un problema al intentar registrar al usuario, Inténtalo de nuevo.");
							map.put("statusCode", HttpStatus.NOT_FOUND.value());
						
							return ResponseEntity.ok().body(map);
							
						}
						
					}else {
					
						map.put("message", "Usuario ya existe.");
						map.put("statusCode", HttpStatus.CONFLICT.value());
					
						return ResponseEntity.ok().body(map);
						
					}
					
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
	
	@ApiOperation(value = "Servicio para actualizar un usuario existente por Id")
	@PutMapping("updateById/{id}")
	public ResponseEntity<Map<String, Object>> updateById(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("id") long id, @RequestBody User user, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User userExisting = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && userExisting  != null && (userExisting .getIdProfile() == 1 || userExisting.getId() == id) && userExisting .getStatus() == 1) {

				if(user.getId() == null) {
					
					map.put("message", "El Id es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}
				else if(user.getIdProfile() == null) {
					
					map.put("message", "El IdProfile es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(user.getFullName() == null || user.getFullName().isEmpty()) {
					
					map.put("message", "El FullName es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(user.getCountry() == null || user.getCountry().isEmpty()) {
					
					map.put("message", "El Country es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(user.getCity() == null || user.getCity().isEmpty()) {
					
					map.put("message", "El City es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(user.getAddress() == null || user.getAddress().isEmpty()) {
					
					map.put("message", "El Address es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(user.getEmail() == null || user.getEmail().isEmpty()) {
					
					map.put("message", "El Email es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {
				
					User userExistingId = userService.findById(id);
					
					if(userExistingId != null) {
					
						User userExistingEmail = userService.findByEmail(user.getEmail());
						
						if(userExistingEmail == null || userExistingEmail.getId() == id) {
							
							User userUpdated = userService.updateById(user);
							
							if(userUpdated != null) {
								
								EventLog eventLog = new EventLog();
								
								eventLog.setIdEventType(1);
								eventLog.setIdUser(sessionToken.getIdUser());
								eventLog.setHost(httpServletRequest.getRemoteAddr());
								eventLog.setHttpMethod(httpServletRequest.getMethod());
								eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
								eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
								
								eventLogService.create(eventLog);
								
								map.put("message", "El usuario se actualizo con éxito.");
								map.put("statusCode", HttpStatus.OK.value());
							
								return ResponseEntity.ok().body(map);
								
							}else {

								map.put("message", "Hubo un problema al intentar actualizar al usuario, Inténtalo de nuevo..");
								map.put("statusCode", HttpStatus.NOT_FOUND.value());
							
								return ResponseEntity.ok().body(map);
								
							}
							
						}else {
						
							map.put("message", "Usuario ya existe.");
							map.put("statusCode", HttpStatus.CONFLICT.value());
						
							return ResponseEntity.ok().body(map);
							
						}
						
					}else {

						map.put("message", "El usuario no existe.");
						map.put("statusCode", HttpStatus.NOT_FOUND.value());
					
						return ResponseEntity.ok().body(map);
					}
					
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
	
	@ApiOperation(value = "Servicio para actualizar la propiedad Status de un usuario existente por Id")
	@PutMapping("updateStatusById/{id}")
	public ResponseEntity<Map<String, Object>> updateStatusById(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("id") long id, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user  != null && user.getIdProfile() == 1 && user.getStatus() == 1) {

				User userExisting = userService.findById(id);
				
				if(userExisting != null) {
				
					User userUpdated = userService.updateStatusById(id);
					
					if(userUpdated != null) {
						
						EventLog eventLog = new EventLog();
						
						eventLog.setIdEventType(1);
						eventLog.setIdUser(sessionToken.getIdUser());
						eventLog.setHost(httpServletRequest.getRemoteAddr());
						eventLog.setHttpMethod(httpServletRequest.getMethod());
						eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
						eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
						
						eventLogService.create(eventLog);
						
						map.put("message", "El usuario se actualizo con éxito.");
						map.put("statusCode", HttpStatus.OK.value());
					
						return ResponseEntity.ok().body(map);
						
					}else {

						map.put("message", "Hubo un problema al intentar actualizar al usuario, Inténtalo de nuevo..");
						map.put("statusCode", HttpStatus.NOT_FOUND.value());
					
						return ResponseEntity.ok().body(map);
						
					}
					
				}else {

					map.put("message", "El usuario no existe.");
					map.put("statusCode", HttpStatus.NOT_FOUND.value());
				
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
}
