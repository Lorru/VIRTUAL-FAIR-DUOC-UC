package cl.virtualfair.models.virtualfair;

import java.io.Serializable;
import java.time.LocalDateTime;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

import org.hibernate.annotations.Proxy;

@Entity
@Table(name="EVENT_LOG")
@Proxy(lazy=false)
public class EventLog implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="EVENT_LOG_SEQ")
	@SequenceGenerator(name="EVENT_LOG_SEQ", sequenceName="EVENT_LOG_SEQ", allocationSize=1)
	@Column(name="ID")
	private long Id;

	@Column(name="ID_EVENT_TYPE")
	private long IdEventType;
	
	@Column(name="ID_USER", nullable = true)
	private Long IdUser;
	
	@Column(name="CONTROLLER")
	private String Controller;
	
	@Column(name="METHOD")
	private String Method;
	
	@Column(name="HTTP_METHOD")
	private String HttpMethod;
	
	@Column(name="HOST")
	private String Host;
	
	@Column(name="MESSAGE")
	private String Message;
	
	@Column(name="EVENT_DATE")
	private LocalDateTime EventDate;

	public EventLog() {
	}
	
	public EventLog(long id) {
		Id = id;
	}
	
	public EventLog(long id, long idEventType, Long idUser, String controller, String method, String httpMethod,
			String host, String message, LocalDateTime eventDate) {
		Id = id;
		IdEventType = idEventType;
		IdUser = idUser;
		Controller = controller;
		Method = method;
		HttpMethod = httpMethod;
		Host = host;
		Message = message;
		EventDate = eventDate;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public long getIdEventType() {
		return IdEventType;
	}

	public void setIdEventType(long idEventType) {
		IdEventType = idEventType;
	}

	public Long getIdUser() {
		return IdUser;
	}

	public void setIdUser(Long idUser) {
		IdUser = idUser;
	}

	public String getController() {
		return Controller;
	}

	public void setController(String controller) {
		Controller = controller;
	}

	public String getMethod() {
		return Method;
	}

	public void setMethod(String method) {
		Method = method;
	}

	public String getHttpMethod() {
		return HttpMethod;
	}

	public void setHttpMethod(String httpMethod) {
		HttpMethod = httpMethod;
	}

	public String getHost() {
		return Host;
	}

	public void setHost(String host) {
		Host = host;
	}

	public String getMessage() {
		return Message;
	}

	public void setMessage(String message) {
		Message = message;
	}

	public LocalDateTime getEventDate() {
		return EventDate;
	}

	public void setEventDate(LocalDateTime eventDate) {
		EventDate = eventDate;
	}
}
