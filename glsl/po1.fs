
precision mediump float;

varying vec3 v_position, v_normal;

uniform vec3 pill_end, pill_start;
uniform float pill_radius;

void main() {
  vec3 pill_dir = pill_end - pill_start;
  float pill_length = length(pill_dir);
  pill_dir /= pill_length;

  float closest_t = dot(v_position - pill_start, pill_dir);
  closest_t = clamp(closest_t, 0.0, pill_length);
  float min_remain = min(closest_t, pill_length - closest_t) + pill_radius;
  
  vec3 approach = closest_t*pill_dir + pill_start - v_position;
  float approach_length = length(approach);
  float approach_distance = max(approach_length - pill_radius, 0.0);

  float hypo_length = sqrt(min_remain*min_remain + approach_length*approach_length);
  float coverage = min_remain / hypo_length;

  if (approach_length < 0.000001) approach_length = 1.0;
  approach /= approach_length;
  float approach_dot = max(dot(approach, v_normal), 0.0);

  float factor = coverage*approach_dot/(1.0 + approach_distance);
  float value = 1.0 - factor*factor;
  gl_FragColor = vec4(value, value, value, 1.0);
}

