export interface SendMessageRequest {
  userId: number;
  message: string;
  messageUser: string;
  lastIndex: number;
  messageType: number;
}
