package cl.virtualfair.models.virtualfair;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

import org.hibernate.annotations.Proxy;

@Entity
@Table(name="EVENT_TYPE")
@Proxy(lazy=false)
public class EventType implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="EVENT_TYPE_SEQ")
	@SequenceGenerator(name="EVENT_TYPE_SEQ", sequenceName="EVENT_TYPE_SEQ", allocationSize=1)
	@Column(name="ID")
	private long Id;

	@Column(name="NAME")
	private String Name;

	public EventType() {
	}
	
	public EventType(long id) {
		Id = id;
	}

	public EventType(long id, String name) {
		Id = id;
		Name = name;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public String getName() {
		return Name;
	}

	public void setName(String name) {
		Name = name;
	}
}
