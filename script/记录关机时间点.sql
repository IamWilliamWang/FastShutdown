UPDATE [Table]
SET �ػ�ʱ�� = GETDATE(), ʱ�� = GETDATE() - ����ʱ��
WHERE ��� in
(SELECT MAX(���)
FROM[Table])