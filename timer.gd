extends Timer

@onready var timer: Timer = $"."

func _on_kill_zone_body_entered(body: Node2D) -> void:
	print('you died')


func _on_timeout() -> void:
	get_tree().reload_current_scene()
