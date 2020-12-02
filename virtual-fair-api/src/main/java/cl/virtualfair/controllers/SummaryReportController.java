package cl.virtualfair.controllers;

import java.util.HashMap;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import cl.virtualfair.models.other.SummaryReport;
import cl.virtualfair.models.virtualfair.EventLog;
import cl.virtualfair.models.virtualfair.SessionToken;
import cl.virtualfair.models.virtualfair.User;
import cl.virtualfair.services.other.SummaryReportService;
import cl.virtualfair.services.virtualfair.EventLogService;
import cl.virtualfair.services.virtualfair.SessionTokenService;
import cl.virtualfair.services.virtualfair.UserService;
import io.swagger.annotations.ApiOperation;

@RestController
@RequestMapping("/api/SummaryReport/")
@CrossOrigin
public class SummaryReportController {

	@Autowired
	private SummaryReportService summaryReportService;
	
	@Autowired
	private UserService userService;
	
	@Autowired
	private SessionTokenService sessionTokenService;
	
	@Autowired
	private EventLogService eventLogService;

	@ApiOperation(value = "Servicio para obtener reporte de las pérdidas por rango de fecha por la propiedad UpdateDate")
	@GetMapping("findByIdPurchaseRequestStatusInTwoNineAndUpdateDate/{updateDateOf}/{updateDateTo}")
	public ResponseEntity<Map<String, Object>> findByIdPurchaseRequestStatusInTwoNineAndUpdateDate(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("updateDateOf")String updateDateOf, @PathVariable("updateDateTo")String updateDateTo, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 2 && user.getStatus() == 1) {
			
				SummaryReport summaryReport = summaryReportService.findByIdPurchaseRequestStatusInTwoNineAndUpdateDate(updateDateOf, updateDateTo);
				
				if(summaryReport != null) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("summaryReport", summaryReport);
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("message", "No existen perdidas para el rango de fecha.");
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
	
	@ApiOperation(value = "Servicio para obtener archivo en base64 de reporte de las pérdidas por rango de fecha por la propiedad UpdateDate")
	@GetMapping("findByIdPurchaseRequestStatusInTwoNineAndUpdateDatePdf/{updateDateOf}/{updateDateTo}")
	public ResponseEntity<Map<String, Object>> findByIdPurchaseRequestStatusInTwoNineAndUpdateDatePdf(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("updateDateOf")String updateDateOf, @PathVariable("updateDateTo")String updateDateTo, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 2 && user.getStatus() == 1) {
			
				String file = summaryReportService.findByIdPurchaseRequestStatusInTwoNineAndUpdateDatePdf(updateDateOf, updateDateTo);
				
				String fileType = ".pdf";
				String fileName = "Reporte_Perdidas_" + updateDateOf.toString() + "_" + updateDateTo.toString();
				
				if(file != null && !file.isEmpty()) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("file", file);
					map.put("fileName", fileName);
					map.put("fileType", fileType);
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("message", "No existen perdidas para el rango de fecha para exportar.");
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
