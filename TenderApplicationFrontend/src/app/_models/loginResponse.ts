export interface LoginResponse {
  token: string;
  username: string;
  expirationDate: number;
  role: string;
}
