export function emailToUsername(email: string) {
  const numberOfCharactersForEmailEnding = -12;
  return email.slice(0, numberOfCharactersForEmailEnding);
}
