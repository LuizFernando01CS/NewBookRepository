export interface ChatIAResponse {
    messages: Message[];
}

export interface Message {
    userName: string,
    message: string,
    index: number,
    messageType: number,
    creationDate: string
  }