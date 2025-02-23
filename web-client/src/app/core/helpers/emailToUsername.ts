export function emailToUsername(email: string) {
  return email.split('@')[0];
}
